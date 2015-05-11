using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrblHeightProbe2
{
	public partial class NewHeightMap : Form
	{
		Settings Set = Settings.Default;

		public NewHeightMap()
		{
			InitializeComponent();
		}

		private void ValueChanged(object sender, EventArgs e)
		{
			textBoxPreviewX.Text = string.Format("{0} - {1}mm", numericUpDownOffsetX.Value, numericUpDownGridSize.Value * (numericUpDownPointsX.Value - 1) + numericUpDownOffsetX.Value);
			textBoxPreviewY.Text = string.Format("{0} - {1}mm", numericUpDownOffsetY.Value, numericUpDownGridSize.Value * (numericUpDownPointsY.Value - 1) + numericUpDownOffsetY.Value);
		}

		private void NewHeightMap_Load(object sender, EventArgs e)
		{
			numericUpDownPointsX.Value = Set.NewHeightMapPoints.Width;
			numericUpDownPointsY.Value = Set.NewHeightMapPoints.Height;
			numericUpDownOffsetX.Value = (decimal)Set.NewHeightMapOffset.Width;
			numericUpDownOffsetY.Value = (decimal)Set.NewHeightMapOffset.Height;
			numericUpDownGridSize.Value = (decimal)Set.NewHeightMapGridSize;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Set.NewHeightMapPoints = new Size((int)numericUpDownPointsX.Value, (int)numericUpDownPointsY.Value);
			Set.NewHeightMapOffset = new SizeF((float)numericUpDownOffsetX.Value, (float)numericUpDownOffsetY.Value);
			Set.NewHeightMapGridSize = (float)numericUpDownGridSize.Value;

			Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
