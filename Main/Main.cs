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
			HeightMapUpdated += Main_HeightMapUpdated;
			GRBL.OnLineReceived += GRBL_OnLineReceived_Console;
			GRBL.OnLineSent += GRBL_OnLineSent_Console;
		}

		void Main_HeightMapUpdated()
		{
			CurrentMap_RedrawPreview();
		}

		private void pictureBoxPreview_SizeChanged(object sender, EventArgs e)
		{
			CurrentMap_RedrawPreview();
		}

	}
}
