using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrblHeightProbe2
{
	partial class GCodePreview : Form
	{
		void RedrawPreview()
		{
			Stopwatch stopW = Stopwatch.StartNew();

			if (pictureBox1.Image != null)
			{
				pictureBox1.Image.Dispose();
				pictureBox1.Image = null;
			}

			Bounds dimensions = Commands.Dimensions();
			dimensions.MinX -= 5;
			dimensions.MaxX += 5;
			dimensions.MinY -= 5;
			dimensions.MaxY += 5;

			float pxPerMM = Math.Min(
				(float)pictureBox1.Width / dimensions.SizeX,
				(float)pictureBox1.Height / dimensions.SizeY);

			Bitmap b = new Bitmap((int)(dimensions.SizeX * pxPerMM), (int)(dimensions.SizeY * pxPerMM));

			Graphics gfx = Graphics.FromImage(b);

			gfx.Clear(Color.Snow);

			float pensize = Math.Min(pictureBox1.Width, pictureBox1.Height) / 360f;
			if (pensize < 1)
				pensize = 1;

			Pen straightPen = new Pen(Color.Black, pensize);
			Pen rapidPen = new Pen(Color.Gray, pensize / 2f);
			Pen arcPen = new Pen(Color.DarkBlue, pensize);

			Func<float, float> getX = (x) => { return (x - dimensions.MinX) * pxPerMM; };
			Func<float, float> getY = (y) => { return b.Height - (y - dimensions.MinY) * pxPerMM; };
			Func<float, float> deg = (rad) => { return rad * 180 / (float)Math.PI; };

			foreach (GCodeCommand command in Commands)
			{
				Arc arc = command as Arc;

				if (arc != null)
				{
					//System.Drawing interprets angles in exactly the opposite of the "industry standard" System.Math way ... thanks for that MS
					//countless hours of trial and error rearranging these few lines... don't you dare touch them
					float start = 360 - deg(arc.StartAngle);
					float end = 360 - deg(arc.EndAngle);

					float sweepAngle = start - end;

					if (sweepAngle < 0)
						sweepAngle += 360;
					
					if(arc.Direction == ArcDirection.CW)
					{
						sweepAngle = 360 - sweepAngle;
					}
					else
					{
						start = end;
					}

					gfx.DrawArc(arcPen,
						getX(arc.Center.X - arc.Radius),
						getY(arc.Center.Y + arc.Radius),
						arc.Radius * 2 * pxPerMM,
						arc.Radius * 2 * pxPerMM,
						start,
						sweepAngle
						);
				}

				Straight str = command as Straight;

				if (str != null)
				{
					gfx.DrawLine(str.Rapid ? rapidPen : straightPen,
						getX(str.Start.X),
						getY(str.Start.Y),
						getX(str.End.X),
						getY(str.End.Y)
						);
				}
			}

			gfx.Flush();

			gfx.Dispose();
			straightPen.Dispose();
			rapidPen.Dispose();

			pictureBox1.Image = b;

			stopW.Stop();
			Console.WriteLine("Updating GCode Preview: {0} ms", stopW.Elapsed.TotalMilliseconds);
		}
	}
}
