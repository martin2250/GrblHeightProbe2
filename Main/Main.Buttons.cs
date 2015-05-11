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

			foreach (string PortName in SerialPort.GetPortNames())
			{
				ToolStripMenuItem PortItem = new ToolStripMenuItem(PortName);
				PortItem.Click += PortItem_Click;
				openPortToolStripMenuItem.DropDownItems.Add(PortItem);
			}
		}

		private void PortItem_Click(object sender, EventArgs e)
		{
			if (GRBL.Connected)
			{
				MessageBox.Show("Close connection first!");
				return;
			}

			try
			{
				SerialPort serialPort = new SerialPort(((ToolStripMenuItem)sender).Text, Set.SerialBaudRate);
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

				CurrentMap.OnPointAdded += CurrentMap_OnPointAdded;
				CurrentMap_OnPointAdded();

				toolStripButtonStart.Enabled = GRBL.Connected;
			}
		}

		void CurrentMap_OnPointAdded()
		{
			if (pictureBoxPreview.Image != null)
				pictureBoxPreview.Image.Dispose();

			pictureBoxPreview.Image = CurrentMap.GetPreview();
		}
	}
}
