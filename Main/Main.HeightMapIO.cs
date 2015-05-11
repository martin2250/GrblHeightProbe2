using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
				CurrentMap.OnPointAdded += CurrentMap_OnPointAdded;

				CurrentMap_OnPointAdded();

				toolStripButtonStart.Enabled = (CurrentMap.NotProbed.Count > 0) & GRBL.Connected;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not open HeightMap\n" + ex.Message);
			}
		}
	}
}
