using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrblHeightProbe2
{
	public partial class Main : Form
	{
		HeightMap CurrentMap = null;

		static Regex ProbeSplit = new Regex(@"\[PRB:(-?[\d.]*),(-?[\d.]*),(-?[\d.]*):?(0|1)?\]", RegexOptions.Compiled);
		static Regex StatusWorkSplit = new Regex(@"WPos:(-?[\d.]*),(-?[\d.]*),(-?[\d.]*)", RegexOptions.Compiled);
		static Regex StatusMachineSplit = new Regex(@"MPos:(-?[\d.]*),(-?[\d.]*),(-?[\d.]*)", RegexOptions.Compiled);

		float OffsetZ = 0;

		/// <summary>
		/// Processes a line from GRBL while probing is running
		/// </summary>
		/// <param name="line"></param>
		void GRBL_OnLineReceived(string line)
		{
			switch (line[0])
			{
				//ok - do nothing
				case 'o':
					break;
				//Probe result
				case '[':
					{
						Match probe = ProbeSplit.Match(line);
						float ZProbe = probe.Groups[3].Value.ToF() + OffsetZ;

						Point CurrentProbePoint = CurrentMap.NotProbed.Dequeue();
						CurrentMap[CurrentProbePoint.X, CurrentProbePoint.Y] = ZProbe;

						//Probing done?
						if (CurrentMap.NotProbed.Count == 0)
						{
							GRBL.ProbingRunning = false;
							Invoke(new Action(() => { toolStripButtonPause.Enabled = false; }));
							GRBL.OnLineReceived -= GRBL_OnLineReceived;
							GRBL.SendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "G0Z{0:F3}", Set.Safety));
							GRBL.SendLine("G0X0Y0");
							return;
						}

						Point nextProbe = CurrentMap.NotProbed.Peek();
						PointF nextProbeF = CurrentMap.GetCoordinates(nextProbe);

						GRBL.SendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "G0Z{0:F3}", Math.Max(Set.Safety, Set.Safety + CurrentMap.HighestNeighbour(nextProbe.X, nextProbe.Y))));
						GRBL.SendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "G0X{0:F3}Y{1:F3}", nextProbeF.X, nextProbeF.Y));
						GRBL.SendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "G38.2Z{0:F3}F{1:F0}", Set.ProbeDepth, Set.ProbePlunge));
					}
					break;
				//Initial response to ? --> find out Z offset (work vs machine pos)
				case '<':
					{
						Match machine = StatusMachineSplit.Match(line);
						Match work = StatusWorkSplit.Match(line);

						OffsetZ = work.Groups[3].Value.ToF() - machine.Groups[3].Value.ToF();


						Point nextProbe = CurrentMap.NotProbed.Peek();
						PointF nextProbeF = CurrentMap.GetCoordinates(nextProbe);

						GRBL.SendLine("G90G21");
						GRBL.SendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "G0Z{0:F3}", Math.Max(Set.Safety, Set.Safety + CurrentMap.HighestNeighbour(nextProbe.X, nextProbe.Y))));

						GRBL.SendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "G0X{0:F3}Y{1:F3}", nextProbeF.X, nextProbeF.Y));
						GRBL.SendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "G38.2Z{0:F3}F{1:F0}", Set.ProbeDepth, Set.ProbePlunge));
					}
					break;
				//unexpected response - pause + report message
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

		private void toolStripButtonStart_Click(object sender, EventArgs e)
		{
			if (CurrentMap != null && CurrentMap.NotProbed.Count > 0)
			{
				GRBL.ProbingRunning = true;

				GRBL.OnLineReceived += GRBL_OnLineReceived;

				GRBL.SendLine("?");

				toolStripButtonStart.Enabled = false;
				toolStripButtonPause.Enabled = true;
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
	}
}
