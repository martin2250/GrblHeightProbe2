using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace GrblHeightProbe2
{
	class GCodeParser
	{
		static System.Globalization.CultureInfo inv = System.Globalization.CultureInfo.InvariantCulture;
		static Regex GCodeSplitter = new Regex(@"([A-Z])(\-?\d+\.?\d*)", RegexOptions.Compiled);

		private ParseDistanceMode DistanceMode = ParseDistanceMode.Absolute;
		private ParseDistanceMode ArcDistanceMode = ParseDistanceMode.Incremental;
		private DistanceUnit Units = DistanceUnit.MM;
		private Vector3 Position = new Vector3(0.0001f, 0.0001f, 0.0001f);

		private GCodeCommand ParseLine(MatchCollection matches)
		{
			if (matches[0].Groups[1].Value != "G")
				return new OtherCode(matches);

			if (matches[0].Groups[2].Value.Contains('.'))
				return new OtherCode(matches);

			int Command = int.Parse(matches[0].Groups[2].Value, inv);

			float? X = null, Y = null, Z = null, I = null, J = null, F = null, R = null;

			for (int index = 1; index < matches.Count; index++)
			{
				float value = float.Parse(matches[index].Groups[2].Value, inv);

				if (Units == DistanceUnit.Inches)
					value *= 25.4f;

				switch (matches[index].Groups[1].Value)
				{
					case "X": X = value; break;
					case "Y": Y = value; break;
					case "Z": Z = value; break;
					case "I": I = value; break;
					case "J": J = value; break;
					case "F": F = value; break;
					case "R": R = value; break;
				}
			}

			Vector3 EndPosition = new Vector3(Position);

			if (X.HasValue)
			{
				EndPosition.X = (DistanceMode == ParseDistanceMode.Absolute) ? (float)X : EndPosition.X + (float)X;
			}

			if (Y.HasValue)
			{
				EndPosition.Y = (DistanceMode == ParseDistanceMode.Absolute) ? (float)Y : EndPosition.Y + (float)Y;
			}

			if (Z.HasValue)
			{
				EndPosition.Z = (DistanceMode == ParseDistanceMode.Absolute) ? (float)Z : EndPosition.Z + (float)Z;
			}

			switch (Command)
			{
				case 0:
					{
						Straight s = new Straight(Position, EndPosition, true);

						if (EndPosition != Position)
						{
							Position = EndPosition;
							return s;
						}
						return null;
					}
				case 1:
					{
						Straight s = new Straight(Position, EndPosition, false);
						s.FeedRate = F;

						if (EndPosition != Position)
						{
							Position = EndPosition;
							return s;
						}
						return null;
					}
				case 2:
				case 3:
					{
						Vector3 center = new Vector3(Position);

						if (I.HasValue)
						{
							center.X = (ArcDistanceMode == ParseDistanceMode.Absolute) ? (float)I : Position.X + (float)I;
						}

						if (J.HasValue)
						{
							center.Y = (ArcDistanceMode == ParseDistanceMode.Absolute) ? (float)J : Position.Y + (float)J;
						}

						if (R.HasValue)
						{
							Vector3 Parallel = EndPosition - Position;
							Vector3 Perpendicular = Parallel.CrossProduct(new Vector3(0, 0, 1));

							float PerpLength = (float)Math.Sqrt(((float)R * (float)R) - (Parallel.Magnitude * Parallel.Magnitude / 4));

							if (Command == 3 ^ R < 0)
								PerpLength = -PerpLength;

							Perpendicular *= PerpLength / Perpendicular.Magnitude;

							center = Position + (Parallel / 2) + Perpendicular;
						}

						Arc a = new Arc(Position, EndPosition, center, Command == 2 ? ArcDirection.CW : ArcDirection.CCW);
						a.FeedRate = F;

						Position = EndPosition;
						return a;
					}
				case 20:
					Units = DistanceUnit.Inches;
					return null;
				case 21:
					Units = DistanceUnit.MM;
					return null;
				case 90:
					DistanceMode = ParseDistanceMode.Absolute;
					return null;
				case 91:
					DistanceMode = ParseDistanceMode.Incremental;
					return null;
			}

			return new OtherCode(matches);
		}

		public GCodeParser()
		{

		}

		public List<GCodeCommand> Parse(string path)
		{
			return Parse(new StreamReader(path));
		}

		public List<GCodeCommand> Parse(StreamReader file)
		{
			DistanceMode = ParseDistanceMode.Absolute;
			ArcDistanceMode = ParseDistanceMode.Incremental;
			Units = DistanceUnit.MM;
			Position = new Vector3(0.0001f, 0.0001f, 0.0001f);

			List<GCodeCommand> Commands = new List<GCodeCommand>();

			try
			{
				while (!file.EndOfStream)
				{
					string input = file.ReadLine();

					int index = input.IndexOf(';');
					if (index >= 0)
						input = input.Substring(0, index);

					index = input.IndexOf('(');
					if (index >= 0)
						input = input.Substring(0, index);

					MatchCollection matches = GCodeSplitter.Matches(input);

					if (matches.Count == 0)
						continue;

					GCodeCommand Command = ParseLine(matches);

					if (Command != null)
						Commands.Add(Command);
				}
			}
			finally
			{
				file.Close();
			}

			return Commands;
		}

		public static void SaveCommands(IEnumerable<GCodeCommand> commands, string path)
		{
			SaveCommands(commands, new StreamWriter(path));
		}

		public static void SaveCommands(IEnumerable<GCodeCommand> commands, StreamWriter file)
		{
			try
			{
				file.WriteLine("G90");
				file.WriteLine("G21");
				file.WriteLine();

				foreach (GCodeCommand Command in commands)
				{
					file.WriteLine(Command.GetGCode());
				}
			}
			finally 
			{ 
				file.Close(); 
			}			
		}

		public static IEnumerable<GCodeCommand> ApplyHeightMap(IEnumerable<GCodeCommand> Commands, HeightMap map)
		{
			foreach (GCodeCommand command in Commands)
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


		enum ParseDistanceMode
		{
			Absolute,
			Incremental
		}
		enum DistanceUnit
		{
			MM,
			Inches
		}

	}
}
