using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrblHeightProbe2
{
	public partial class Main : Form
	{
		const int border = 2;
		int PixelsPerCheck = 1;
		Size ActPreviewSize = new Size();

		Image GetPreview(HeightMap map, Size ImgSize)
		{
			System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();
			s.Start();

			//Determine Size of single Check (without two pixel border
			//according to http://www.wolframalpha.com/input/?i=solve+s%3Dg*%28x+-+1%29+%2Bb+*+x+for+g
			PixelsPerCheck = Math.Min(
				(ImgSize.Width - border * map.SizeX) / (map.SizeX - 1),
				(ImgSize.Height - border * map.SizeY) / (map.SizeY - 1));

			ActPreviewSize = new Size(PixelsPerCheck * (map.SizeX - 1) + map.SizeX * border, PixelsPerCheck * (map.SizeY - 1) + map.SizeY * border);

			Bitmap b = new Bitmap(ActPreviewSize.Width, ActPreviewSize.Height);
					
			Graphics gfx = Graphics.FromImage(b);

			for (int x = 0; x < map.SizeX - 1; x++)
			{
				for (int y = 0; y < map.SizeY - 1; y++)
				{
					if (!(map.HasValue[x, y] && map.HasValue[x + 1, y] && map.HasValue[x, y + 1] && map.HasValue[x + 1, y + 1]))
						continue;

					int offsetX = x * (border + PixelsPerCheck) + border;
					int offsetY = b.Size.Height - 2 - ((y + 1) * (border + PixelsPerCheck)) + border;

					GraphicsPath rectpath = new GraphicsPath();

					rectpath.AddLine(offsetX + 0,				offsetY + PixelsPerCheck,	offsetX + PixelsPerCheck,	offsetY + PixelsPerCheck);
					rectpath.AddLine(offsetX + PixelsPerCheck,	offsetY + PixelsPerCheck,	offsetX + PixelsPerCheck,	offsetY + 0);
					rectpath.AddLine(offsetX + PixelsPerCheck,	offsetY + 0,				offsetX + 0,				offsetY + 0);

					PathGradientBrush brush = new PathGradientBrush(rectpath);
					brush.SurroundColors = new Color[] 
					{
						Helpers.ColorFromHeight(map[x, y], map.MinZ, map.MaxZ),
						Helpers.ColorFromHeight(map[x + 1, y], map.MinZ, map.MaxZ),
						Helpers.ColorFromHeight(map[x + 1, y + 1], map.MinZ, map.MaxZ),
						Helpers.ColorFromHeight(map[x, y + 1], map.MinZ, map.MaxZ)
					};

					PointF center = map.GetCoordinates(new Point(x, y));
					center.X += map.GridSize / 2;
					center.Y += map.GridSize / 2;
					brush.CenterColor = Helpers.ColorFromHeight(map.GetHeightAt(center), map.MinZ, map.MaxZ);

					gfx.FillRectangle(brush,
						offsetX,
						offsetY,
						PixelsPerCheck,
						PixelsPerCheck
						);

					rectpath.Dispose();
					brush.Dispose();
				}
			}

			Pen crossPen = new Pen(Color.Black, 2);

			for (int x = 0; x < map.SizeX; x++)
			{
				for (int y = 0; y < map.SizeY; y++)
				{
					gfx.DrawLine(crossPen,
						x * (PixelsPerCheck + border) + .5f,
						ActPreviewSize.Height - (y * (PixelsPerCheck + border)) + 4,
						x * (PixelsPerCheck + border) + .5f,
						ActPreviewSize.Height - (y * (PixelsPerCheck + border)) - 6
						);
					
					gfx.DrawLine(crossPen,
						x * (PixelsPerCheck + border) - 4,
						ActPreviewSize.Height - y * (PixelsPerCheck + border) - 1.5f,
						x * (PixelsPerCheck + border) + 6,
						ActPreviewSize.Height - y * (PixelsPerCheck + border) - 1.5f
						);
				}
			}

			gfx.Dispose();

			s.Stop();
			Console.WriteLine(s.Elapsed);

			return b;
		}

		void CurrentMap_RedrawPreview()
		{
			if (CurrentMap == null)
				return;

			if (pictureBoxPreview.Image != null)
				pictureBoxPreview.Image.Dispose();

			pictureBoxPreview.Image = GetPreview(CurrentMap, pictureBoxPreview.Size);
		}

		Point previousMouse = new Point(0, 0);
		
		private void pictureBoxPreview_MouseMove(object sender, MouseEventArgs e)
		{
			if (CurrentMap == null)
				return;

			if (previousMouse != e.Location)
			{
				int x = (int)Math.Round((float)e.Location.X / (PixelsPerCheck + border));
				int y = (int)Math.Round((float)(ActPreviewSize.Height - e.Location.Y) / (PixelsPerCheck + border));

				if(x >= CurrentMap.SizeX || y >= CurrentMap.SizeY || x < 0 || y < 0)
				{
					toolTip.RemoveAll();
					return;
				}

				PointF coords = CurrentMap.GetCoordinates(x, y);

				toolTip.SetToolTip(pictureBoxPreview, string.Format("({0:0.##}|{1:0.##}):{2:0.###}", coords.X , coords.Y, CurrentMap[x, y]));
				previousMouse = e.Location;
			}
		}
	}
}
