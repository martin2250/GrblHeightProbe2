using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrblHeightProbe2
{
	abstract class Movement : GCodeCommand
	{
		public Vector3 Start, End;
		public float? FeedRate = null;

		public Movement(Vector3 start, Vector3 end)
		{
			Start = start;
			End = end;
		}

		public abstract float Length { get; }

		public Vector3 Incremental
		{
			get
			{
				return End - Start;
			}
		}
	}
}
