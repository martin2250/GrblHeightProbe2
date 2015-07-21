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
		private void applyToFilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialogGCode.ShowDialog();
		}

		/// <summary>
		/// Used to generate the new file name
		/// </summary>
		Regex NewPathReg = new Regex(@"(.*)(\.[a-zA-Z]*?)$");

		private void openFileDialogGCode_FileOk(object sender, CancelEventArgs e)
		{
			if (CurrentMap == null || CurrentMap.NotProbed.Count > 0)
				return;

			foreach (string path in openFileDialogGCode.FileNames)
			{
				try
				{
					GCodeParser p = new GCodeParser();

					string newpath = NewPathReg.Replace(path, @"$1.probed$2");

					GCodeParser.SaveCommands(GCodeParser.ApplyHeightMap(p.Parse(path), CurrentMap), newpath);
				}
				catch (Exception ex)
				{
					MessageBox.Show(string.Format("Error while parsing File {0}\n{1}", path, ex.Message));
				}
			}

			MessageBox.Show("Done");
		}

		private void gCodeToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			applyToFilesToolStripMenuItem.Enabled = CurrentMap != null && CurrentMap.NotProbed.Count == 0;
		}

	}
}
