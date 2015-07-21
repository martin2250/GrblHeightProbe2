using System;
using System.Drawing;
using System.Windows.Forms;

namespace GrblHeightProbe2
{
	public partial class Main : Form
	{
		Settings Set = Settings.Default;

		public Main()
		{
			InitializeComponent();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new About().ShowDialog();
		}

		private void pictureBoxPreview_SizeChanged(object sender, EventArgs e)
		{
			CurrentMap_RedrawPreview();
		}
	}
}
