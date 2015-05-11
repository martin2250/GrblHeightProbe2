using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GrblHeightProbe2
{
	class OtherCode : GCodeCommand
	{
		public string Line = "";

		public OtherCode(MatchCollection matches)
		{
			foreach(Match m in matches)
			{
				Line += m.Groups[1];
				Line += m.Groups[2];
			}
		}

		public override string GetGCode()
		{
			return Line;
		}
	}
}
