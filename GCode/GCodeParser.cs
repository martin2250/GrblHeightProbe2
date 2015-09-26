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
		private static System.Globalization.CultureInfo inv = System.Globalization.CultureInfo.InvariantCulture;
		private static Regex GCodeSplitter = new Regex(@"([A-Z])(\-?\d+\.?\d*)", RegexOptions.Compiled);

		public ParseDistanceMode DistanceMode;
		public ParseDistanceMode ArcDistanceMode;
		public DistanceUnit Units;
		public Vector3 Position;
		public int LastCommand;

		public void Reset()
		{
			DistanceMode = ParseDistanceMode.Absolute;
			ArcDistanceMode = ParseDistanceMode.Incremental;
			Units = DistanceUnit.MM;
			Position = new Vector3(0.0f, 0.0f, 0.0f);
			LastCommand = -1;
		}

		public GCodeParser()
		{
			Reset();
		}

		private GCodeCommand ParseLine(MatchCollection matches)
		{
			int Command;

			if (matches[0].Groups[1].Value == "G")
			{
				float CommandF = float.Parse(matches[0].Groups[2].Value, inv);
				Command = (int)CommandF;

				if (CommandF == 90.1)
				{
					ArcDistanceMode = ParseDistanceMode.Absolute;
					return null;
				}

				if (CommandF == 91.1)
				{
					ArcDistanceMode = ParseDistanceMode.Incremental;
					return null;
				}

				if (CommandF != Command)        //All other 'G' commands that have a decimal point
					return new OtherCode(matches);

				LastCommand = Command;
			}
			else
			{
				if ("XYZIJKR".Contains(matches[0].Groups[1].Value))
				{
					Command = LastCommand;
				}
				else
				{
					return new OtherCode(matches);
				}
			}

			float? X = null, Y = null, Z = null, I = null, J = null, F = null, R = null;

			for (int index = 0; index < matches.Count; index++)
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

		public List<GCodeCommand> Parse(StreamReader file)
		{
			List<GCodeCommand> Commands = new List<GCodeCommand>();

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

			file.Close();

			return Commands;
		}

		public enum ParseDistanceMode
		{
			Absolute,
			Incremental
		}

		public enum DistanceUnit
		{
			MM,
			Inches
		}

	}
}
