using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrblHeightProbe2
{
	abstract class GCodeCommand
	{
		public abstract string GetGCode();
	}
}
