using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrblHeightProbe2
{
	public partial class Main : Form
	{
		GCodeParser GParser = new GCodeParser();

		private void openGCodeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialogGCode.ShowDialog();
		}

		public event Action HeightMapUpdated;
		

		private void openFileDialogGCode_FileOk(object sender, CancelEventArgs e)
		{
			foreach (string path in openFileDialogGCode.FileNames)
			{
				TryOpenGCode(path);
			}
		}

		private void TryOpenGCode(string path)
		{
			try
			{
				StreamReader sr = new StreamReader(path);

				try
				{
					GParser.Reset();
					List<GCodeCommand> Commands = GParser.Parse(sr);

					GCodePreview prev = new GCodePreview(Commands, this, path);

					HeightMapUpdated += prev.HeightMapUpdated;

					prev.Show();
					prev.BringToFront();
				}

				catch (Exception ex)
				{
					MessageBox.Show(string.Format("Error while parsing file {0}\n{1}", path, ex.Message));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Error while opening file {0}\n{1}", path, ex.Message));
			}
		}


	}
}
