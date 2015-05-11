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

		HeightMap CurrentMap = null;

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

		Regex ProbeSplit = new Regex(@"\[PRB:(-?[\d.]*),(-?[\d.]*),(-?[\d.]*):?(0|1)?\]", RegexOptions.Compiled);
		Regex StatusWorkSplit = new Regex(@"WPos:(-?[\d.]*),(-?[\d.]*),(-?[\d.]*)", RegexOptions.Compiled);
		Regex StatusMachineSplit = new Regex(@"MPos:(-?[\d.]*),(-?[\d.]*),(-?[\d.]*)", RegexOptions.Compiled);

		float OffsetZ = 0;

		void GRBL_OnLineReceived(string line)
		{
			switch(line[0])
			{
				case 'o':
					break;
				case '[':
					{
						Match probe = ProbeSplit.Match(line);
						float ZProbe = probe.Groups[3].Value.ToF() + OffsetZ;

						Point CurrentProbePoint = CurrentMap.NotProbed.Dequeue();
						CurrentMap[CurrentProbePoint.X, CurrentProbePoint.Y] = ZProbe;

						if(CurrentMap.NotProbed.Count == 0)
						{
							GRBL.ProbingRunning = false;
							Invoke(new Action(() => { toolStripButtonPause.Enabled = false; }));
							GRBL.OnLineReceived -= GRBL_OnLineReceived;
							GRBL.SendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "G0Z{0:F3}", Set.Safety));
							GRBL.SendLine("G0X0Y0");
							return;
						}

						PointF nextProbe = CurrentMap.GetCoordinates(CurrentMap.NotProbed.Peek());
						GRBL.SendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "G0Z{0:F3}", Set.Safety));
						GRBL.SendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "G0X{0:F3}Y{1:F3}", nextProbe.X, nextProbe.Y));
						GRBL.SendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "G38.2Z{0:F3}F{1:F0}", Set.ProbeDepth, Set.ProbePlunge));
					}
					break;

				case '<':
					{
						Match machine = StatusMachineSplit.Match(line);
						Match work = StatusWorkSplit.Match(line);

						OffsetZ = work.Groups[3].Value.ToF() - machine.Groups[3].Value.ToF();

						GRBL.SendLine("G90G21");
						GRBL.SendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "G0Z{0:F3}", Set.Safety));

						PointF firstProbe = CurrentMap.GetCoordinates(CurrentMap.NotProbed.Peek());
						GRBL.SendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "G0X{0:F3}Y{1:F3}", firstProbe.X, firstProbe.Y));
						GRBL.SendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "G38.2Z{0:F3}F{1:F0}", Set.ProbeDepth, Set.ProbePlunge));
					}
					break;
				default:
					{
						GRBL.SendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "G0Z{0:F3}", Set.Safety));
						GRBL.SendLine("G0X0Y0");
						GRBL.ProbingRunning = false;
						toolStripButtonStart.Enabled = true;
						toolStripButtonPause.Enabled = false;
						GRBL.OnLineReceived -= GRBL_OnLineReceived;

						MessageBox.Show("Received error from GRBL:\n" + line);
					}
					break;
			}
		}

		private void toolStripButtonPause_Click(object sender, EventArgs e)
		{
			GRBL.SendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "G0Z{0:F3}", Set.Safety));
			GRBL.SendLine("G0X0Y0");
			GRBL.ProbingRunning = false;
			toolStripButtonStart.Enabled = true;
			toolStripButtonPause.Enabled = false;
			GRBL.OnLineReceived -= GRBL_OnLineReceived;
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
