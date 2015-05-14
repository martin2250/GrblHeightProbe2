using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrblHeightProbe2
{
	public partial class Main : Form
	{
		void CurrentMap_OnPointAdded()
		{
			if (pictureBoxPreview.Image != null)
				pictureBoxPreview.Image.Dispose();

			
		}

		Point previousMouse = new Point(0, 0);
											//http://www.codeproject.com/Articles/20923/Mouse-Position-over-Image-in-a-PictureBox
		private void pictureBoxPreview_MouseMove(object sender, MouseEventArgs e)
		{
			if (previousMouse != e.Location)
			{
				toolTip.SetToolTip(pictureBoxPreview, string.Format("{0} {1}", e.X, e.Y));
				previousMouse = e.Location;
			}
		}
	}
}
