using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrblHeightProbe2
{
	static class Helpers
	{
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
