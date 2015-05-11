using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrblHeightProbe2
{
	enum ArcDirection
	{
		CW,
		CCW
	}

	class Arc : Movement
	{
		public ArcDirection Direction;

		/// <summary>
		/// Absolute Position of Arc Center
		/// </summary>
		public Vector3 Center;

		public Arc(Vector3 start, Vector3 end, Vector3 center, ArcDirection direction) : base(start, end)
		{
			Center = center;
			Center.Z = 0;
			Direction = direction;
		}

		public override string GetGCode()
		{
			string code = (Direction == ArcDirection.CW) ? "G2" : "G3";

			if (End.X != Start.X)
				code += string.Format(System.Globalization.CultureInfo.InvariantCulture, "X{0:0.###}", End.X);
			if (End.Y != Start.Y)
				code += string.Format(System.Globalization.CultureInfo.InvariantCulture, "Y{0:0.###}", End.Y);
			if (End.Z != Start.Z)
				code += string.Format(System.Globalization.CultureInfo.InvariantCulture, "Z{0:0.###}", End.Z);

			if (Center.X != Start.X)
				code += string.Format(System.Globalization.CultureInfo.InvariantCulture, "I{0:0.###}", Center.X - Start.X);
			if (Center.Y != Start.Y)
				code += string.Format(System.Globalization.CultureInfo.InvariantCulture, "J{0:0.###}", Center.Y - Start.Y);

			if (FeedRate.HasValue)
				code += string.Format(System.Globalization.CultureInfo.InvariantCulture, "F{0:F0}", FeedRate);
			return code;
		}

		public float StartAngle
		{
			get
			{
				Vector3 relStart = Start - Center;
				float a = (float)Math.Atan2(relStart.Y, relStart.X);
				return a >= 0 ? a : 2 * (float)Math.PI + a;
			}
		}

		public float EndAngle
		{
			get
			{
				Vector3 relEnd = End - Center;
				float a = (float)Math.Atan2(relEnd.Y, relEnd.X);
				return a >= 0 ? a : 2 * (float)Math.PI + a;
			}
		}

		public float Radius
		{
			// get average between both radii
			get 
			{
				return (float)(
					Math.Sqrt(Math.Pow(Start.X - Center.X, 2) + Math.Pow(Start.Y - Center.Y, 2)) + 
					Math.Sqrt(Math.Pow(End.X - Center.X, 2) + Math.Pow(End.Y - Center.Y, 2))
					) / 2;
			}
		}

		public override float Length
		{
			get
			{
				Vector3 start = new Vector3(Start);
				Vector3 end = new Vector3(End);

				start.Z = 0;
				end.Z = 0;

				float stretch = StartAngle - EndAngle;

				if (stretch < 0)
					stretch += 2 * (float)Math.PI;

				if(Direction == ArcDirection.CCW)
				{
					stretch = 2 * (float)Math.PI - stretch;
				}
				
				return stretch * Radius;
			}
		}
	}
}
