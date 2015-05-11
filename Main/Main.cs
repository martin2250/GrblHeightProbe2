using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Text.RegularExpressions;

namespace GrblHeightProbe2
{
	public partial class Main : Form
	{
		Settings Set = Settings.Default;

		public Main()
		{
			InitializeComponent();
		}

		private void Main_Load(object sender, EventArgs e)
		{

		}

		private void toolStripButtonStart_Click(object sender, EventArgs e)
		{
			if(CurrentMap != null && CurrentMap.NotProbed.Count > 0)
			{
				GRBL.ProbingRunning = true;

				GRBL.OnLineReceived += GRBL_OnLineReceived;

				GRBL.SendLine("?");

				toolStripButtonStart.Enabled = false;
				toolStripButtonPause.Enabled = true;
			}
		}

		

		private void applyToFilesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openFileDialogGCode.ShowDialog();
		}

		Regex NewPathReg = new Regex(@"(.*)(\.[a-zA-Z]*?)$");

		private void openFileDialogGCode_FileOk(object sender, CancelEventArgs e)
		{
			if (CurrentMap == null || CurrentMap.NotProbed.Count > 0)
				return;

			foreach(string path in openFileDialogGCode.FileNames)
			{
				try
				{
					GCodeParser p = new GCodeParser(path);

					string newpath = NewPathReg.Replace(path, @"$1.probed$2");

					GCodeParser.SaveCommands(p.ApplyHeightMap(CurrentMap), new StreamWriter(newpath));
				}
				catch (Exception ex)
				{
					MessageBox.Show(string.Format("Error while parsing File {0}\n{1}", path, ex.Message));
				}
			}
		}

		private void gCodeToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			applyToFilesToolStripMenuItem.Enabled = CurrentMap != null && CurrentMap.NotProbed.Count == 0;
		}

	}
}
