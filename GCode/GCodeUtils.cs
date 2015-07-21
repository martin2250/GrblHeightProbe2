using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrblHeightProbe2
{
	static class GCodeUtils
	{

		public static void SaveCommands(this IEnumerable<GCodeCommand> commands, StreamWriter file)
		{
			file.WriteLine("G90");
			file.WriteLine("G21");
			file.WriteLine();

			foreach (GCodeCommand Command in commands)
			{
				file.WriteLine(Command.GetGCode());
			}

			file.Close();
		}

		public IEnumerable<GCodeCommand> ApplyHeightMap(this IEnumerable<GCodeCommand> commands, HeightMap map)
		{
			foreach (GCodeCommand command in commands)
			{
				if (command is OtherCode)
				{
					yield return command;
					continue;
				}
				else
				{
					Movement m = (Movement)command;

					int divisions = (int)Math.Ceiling(m.Length / map.GridSize);

					if (m is Straight)
					{
						Straight s = (Straight)m;

						if (s.Rapid)
						{
							Vector3 newEnd = s.End;
							newEnd.Z += map.GetHeightAt(s.End.X, s.End.Y);

							yield return new Straight(s.Start, newEnd, true);
						}
						else
						{
							Vector3 pos = s.Start;

							for (int x = 1; x <= divisions; x++)
							{
								Vector3 end = s.Start.Interpolate(s.End, (float)x / (float)divisions);
								end.Z += map.GetHeightAt(end.X, end.Y);
								Straight st = new Straight(pos, end, false);
								if (x == 1)
									st.FeedRate = s.FeedRate;
								yield return st;
								pos = end;
							}
						}
					}
					if (m is Arc)
					{
						Arc a = (Arc)m;

						Vector3 pos = a.Start;

						float stretch = a.StartAngle - a.EndAngle;

						if (stretch <= 0)
							stretch += 2 * (float)Math.PI;

						if (a.Direction == ArcDirection.CCW)
						{
							stretch = 2 * (float)Math.PI - stretch;
						}

						if (stretch <= 0)
							stretch += 2 * (float)Math.PI;

						for (int x = 1; x <= divisions; x++)
						{
							Vector3 end = new Vector3(a.Radius, 0, 0);

							if (a.Direction != ArcDirection.CCW)
								end.Roll(a.StartAngle + stretch * (float)x / (float)divisions);
							else
								end.Roll(a.StartAngle - stretch * (float)x / (float)divisions);

							end += a.Center;

							end.Z = a.Start.Z + (a.End.Z - a.Start.Z) * (float)x / (float)divisions;

							end.Z += map.GetHeightAt(end.X, end.Y);

							Arc arc = new Arc(pos, end, a.Center, a.Direction);

							if (x == 1)
								arc.FeedRate = a.FeedRate;

							yield return arc;
							pos = end;
						}
					}
				}
			}

			yield break;
		}

		public Bounds Bounds(this IEnumerable<GCodeCommand> commands)
		{
			Bounds b = new Bounds();
			
			foreach(var Command in commands)
			{
				var MoveCommand = Command as Movement;

				if (MoveCommand == null)
					continue;

				b.ExpandTo(MoveCommand.Start.X, MoveCommand.Start.Y);
				b.ExpandTo(MoveCommand.End.X, MoveCommand.End.Y);
			}

			return b;
		}
	}
}
