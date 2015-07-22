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


namespace GrblHeightProbe2
{
	public partial class Main : Form
	{
		private void connectionToolStripMenuItem1_DropDownOpening(object sender, EventArgs e)
		{
			openPortToolStripMenuItem.Enabled = !GRBL.Connected;
			closePortToolStripMenuItem.Enabled = GRBL.Connected;
			manualConsoleToolStripMenuItem.Enabled = GRBL.Connected & !GRBL.ProbingRunning;
		}

		private void openPortToolStripMenuItem_Click(object sender, EventArgs e)
		{
			openPortToolStripMenuItem.DropDownItems.Clear();

			ToolStripMenuItem otherPortItem = new ToolStripMenuItem("other port");
			otherPortItem.Click += otherPortItem_Click;
			openPortToolStripMenuItem.DropDownItems.Add(otherPortItem);

			foreach (string PortName in SerialPort.GetPortNames())
			{
				ToolStripMenuItem PortItem = new ToolStripMenuItem(PortName);
				PortItem.Click += PortItem_Click;
				openPortToolStripMenuItem.DropDownItems.Add(PortItem);
			}
		}

		void otherPortItem_Click(object sender, EventArgs e)
		{
			EnterText etxt = new EnterText();
			etxt.Text = "Enter port name";
			etxt.ShowDialog();

			if (!etxt.Ok)
				return;

			TryOpenPort(etxt.Result);
		}

		private void PortItem_Click(object sender, EventArgs e)
		{
			TryOpenPort(((ToolStripMenuItem)sender).Text);
		}

		private void TryOpenPort(string name)
		{
			if (GRBL.Connected)
			{
				MessageBox.Show("Close connection first!");
				return;
			}

			try
			{
				SerialPort serialPort = new SerialPort(name, Set.SerialBaudRate);
				serialPort.Open();

				serialPort.DtrEnable = true;
				serialPort.DtrEnable = false;

				serialPort.NewLine = "\r";
				serialPort.DataReceived += GRBL.Port_DataReceived;
				GRBL.Port = serialPort;
				GRBL.ProbingRunning = false;
				serialPort.WriteLine("");

				toolStripButtonStart.Enabled = CurrentMap != null && CurrentMap.NotProbed.Count > 0;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Could not open port\n" + ex.Message);
			}
		}

		private void closePortToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GRBL.Close();
		}

		private void resetToDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Set.Reset();
		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			Set.Save();
		}

		private void generalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new ChangeSettings().ShowDialog();
		}

		private void manualConsoleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new ConsoleWindow().ShowDialog();
		}

		private void newHeightMapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (new NewHeightMap().ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				CurrentMap = new HeightMap(Set.NewHeightMapPoints.Width, Set.NewHeightMapPoints.Height, Set.NewHeightMapGridSize, Set.NewHeightMapOffset.Width, Set.NewHeightMapOffset.Height);

				CurrentMap.OnPointAdded += HeightMapUpdated;

				toolStripButtonStart.Enabled = GRBL.Connected;

				HeightMapUpdated();
			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new About().ShowDialog();
		}

		private void generateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GenHeightMap ghm = new GenHeightMap();
			if (ghm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
				return;

			CurrentMap = ghm.Map;

			CurrentMap.OnPointAdded += HeightMapUpdated;

			toolStripButtonStart.Enabled = false;

			HeightMapUpdated();
		}

		private void reportIssueToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/martin2250/GrblHeightProbe2/issues");
		}
	}
}
