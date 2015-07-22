using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace GrblHeightProbe2
{
	public partial class Main : Form
	{
		private void openHeightMapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialogHMap.ShowDialog();
		}

		private void saveHeightMapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (CurrentMap != null)
				saveFileDialog.ShowDialog();
		}

		private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
		{
			try
			{
				CurrentMap.Save(new BinaryWriter(File.OpenWrite(saveFileDialog.FileName)));
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not save HeightMap\n" + ex.Message);
			}
		}

		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
			try
			{
				CurrentMap = new HeightMap(new BinaryReader(File.OpenRead(openFileDialogHMap.FileName)));
				CurrentMap.OnPointAdded += HeightMapUpdated;

				toolStripButtonStart.Enabled = (CurrentMap.NotProbed.Count > 0) & GRBL.Connected;

				HeightMapUpdated();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not open HeightMap\n" + ex.Message);
			}
		}

		private void exportToCSVToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			saveFileDialogExport.ShowDialog();
		}

		private void saveFileDialogExport_FileOk(object sender, CancelEventArgs e)
		{
			try
			{
				string path = saveFileDialogExport.FileName;

				StreamWriter file = new StreamWriter(path);

				for (int y = CurrentMap.SizeY - 1; y >= 0; y--)
				{
					for (int x = 0; x + 1 < CurrentMap.SizeX; x++)
					{
						file.Write("{0:0.###};", CurrentMap[x, y]);
					}

					file.WriteLine(CurrentMap[CurrentMap.SizeX - 1, y].ToString("0.###"));
				}

				file.WriteLine("Grid Size;{0}", CurrentMap.GridSize);
				file.WriteLine(";X;Y");
				file.WriteLine("Points;{0};{1}", CurrentMap.SizeX, CurrentMap.SizeY);
				file.WriteLine("Offset;{0};{1}", CurrentMap.OffsetX, CurrentMap.OffsetY);

				file.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not write file:\n" + ex.Message);
			}
		}
	}
}
