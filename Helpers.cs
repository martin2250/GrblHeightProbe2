using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrblHeightProbe2
{
	static class Helpers
	{
		public static Color ColorFromHeight(float val, float min, float max)
		{
			if (max > min)
			{
				val -= min;
				val /= (max - min);
			}
			else
				return Color.Green;

			float r = 0, g = 0, b = 0;

			if (val < 0.2)
			{
				b = 1;
				g = 5 * val;
			}
			else if (val < 0.4)
			{
				val -= 0.2F;

				g = 1;
				b = 1 - 5 * val;
			}
			else if (val < 0.6)
			{
				val -= 0.4F;

				g = 1;
				r = 5 * val;
			}
			else if (val < 0.8)
			{
				val -= 0.6F;

				r = 1;
				g = 1 - 5 * val;
			}
			else
			{
				val -= 0.8F;

				r = 1;
				b = 5 * val;
			}

			return Color.FromArgb(255, (int)(r * 255), (int)(g * 255), (int)(b * 255));
		}

		public static string ToS(this float d)
		{
			return Math.Round(d, 3).ToString(System.Globalization.CultureInfo.InvariantCulture);
		}

		public static float ToF(this string s)
		{
			return float.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
		}
	}
}
