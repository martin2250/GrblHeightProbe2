using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrblHeightProbe2
{
	partial class GCodePreview : Form
	{
		public GCodeCommand[] Commands;
		Bounds size;

		/// <summary>
		/// Used to generate the new file name
		/// </summary>
		Regex NewPathReg = new Regex(@"(.*)(\.[a-zA-Z]*?)$");
		//string newpath = NewPathReg.Replace(path, @"$1.probed$2");

		Main main;
		string path;

		bool HeightMapIsValid()
		{
			if (main.CurrentMap == null)
				return false;
			if (!main.CurrentMap.Dimensions.Contains(Commands.Dimensions()))
				return false;
			if (main.CurrentMap.NotProbed.Count > 0)
				return false;

			return true;
		}


		public void HeightMapUpdated()
		{
			if (main.CurrentMap == null)
			{
				labelFitsHeightMap.Text = "";
				return;
			}
			if (!main.CurrentMap.Dimensions.Contains(Commands.Dimensions()))
			{
				labelFitsHeightMap.Text = "Path not contained in HeightMap";
				return;
			}
			if (main.CurrentMap.NotProbed.Count > 0)
			{
				labelFitsHeightMap.Text = "HeightMap not completed";
				return;
			}
			labelFitsHeightMap.Text = "HeightMap can be applied";
		}

		public GCodePreview(IEnumerable<GCodeCommand> commands, Main main, string path)
		{
			Commands = commands.ToArray();
			this.main = main;
			this.path = path;

			InitializeComponent();
			this.Text += path;

			GCodeUpdated();
		}

		private void GCodeUpdated()
		{
			size = Commands.Dimensions();
			labelSize.Text = string.Format("Dimensions: X: {0:0.00} ~ {1:0.00}  Y: {2:0.00} ~ {3:0.00}", size.MinX, size.MaxX, size.MinY, size.MaxY);

			toolStripStatusLabelFill.Text = string.Format("Total distance: {0} mm", Commands.TravelDistance());

			RedrawPreview();
			HeightMapUpdated();
		}

		private void GCodePreview_FormClosing(object sender, FormClosingEventArgs e)
		{
			main.HeightMapUpdated -= HeightMapUpdated;
		}

		private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			applyHeightMapAndSaveToolStripMenuItem.Enabled = HeightMapIsValid();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		GCodeCommand[] ToSave;

		private void applyHeightMapAndSaveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!HeightMapIsValid())
				return;

			try
			{
				ToSave = Commands.ApplyHeightMap(main.CurrentMap).ToArray();
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Error while applying HeightMap \n{0}", ex.Message));
			}

			saveFileDialog1.FileName = NewPathReg.Replace(path, @"$1.probed$2");
			saveFileDialog1.ShowDialog();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToSave = Commands;

			saveFileDialog1.FileName = path;
			saveFileDialog1.ShowDialog();
		}

		private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
			if (ToSave == null)
				return;

			try
			{
				StreamWriter w = new StreamWriter(saveFileDialog1.FileName);

				try
				{
					ToSave.SaveCommands(w);
				}
				catch (Exception ex)
				{
					MessageBox.Show(string.Format("Error while saving file {0}\n{1}", path, ex.Message));
				}

				w.Dispose();
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Error while opening file {0}\n{1}", path, ex.Message));
			}

			labelMessage.Text = "Saved successfully";
		}

		private void labelMessage_Click(object sender, EventArgs e)
		{
			labelMessage.Text = "";
		}

		private void GCodePreview_ResizeEnd(object sender, EventArgs e)
		{
			RedrawPreview();
		}

		private void movePathToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ThreeFloatPicker tfp = new ThreeFloatPicker();
			tfp.Text = "Move / translate toolpath";
			tfp.ShowDialog();

			if(tfp.DialogResult != DialogResult.OK)
				return;

			Vector3 translation = new Vector3((float)tfp.X.Value, (float)tfp.Y.Value, (float)tfp.Z.Value);

			foreach(GCodeCommand cmd in Commands)
			{
				if (cmd is Movement)
				{
					Movement mv = (Movement)cmd;
					mv.Start += translation;
					mv.End += translation;
				}

				if(cmd is Arc)
				{
					Arc a = (Arc)cmd;
					a.Center += translation;
				}
			}

			GCodeUpdated();

			labelMessage.Text = "Translation successful";
		}
	}
}
