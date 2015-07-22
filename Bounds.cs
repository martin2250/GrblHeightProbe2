using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrblHeightProbe2
{
	public class Bounds
	{
		public float MinX { get; set; }
		public float MaxX { get; set; }
		public float MinY { get; set; }
		public float MaxY { get; set; }

		public float SizeX { get { return MaxX - MinX; } }
		public float SizeY { get { return MaxY - MinY; } }

		public Bounds()
		{
			MinX = 0;
			MaxX = 0;
			MinY = 0;
			MaxY = 0;
		}

		public Bounds(float minX, float maxX, float minY, float maxY)
		{
			MinX = minX;
			MaxX = maxX;
			MinY = minY;
			MaxY = maxY;
		}

		/// <summary>
		/// returns true if the other Bounds object is fully contained inside this one
		/// </summary>
		/// <param name="other">The other Bounds object</param>
		/// <returns></returns>
		public bool Contains(Bounds other)
		{
			bool contains = true;

			contains &= MinX <= other.MinX;
			contains &= MaxX >= other.MaxX;
			contains &= MinY <= other.MinY;
			contains &= MaxY >= other.MaxY;

			return contains;
		}

		/// <summary>
		/// Expands the Bounds to contain the given point
		/// </summary>
		/// <param name="x">X coordinate of the point</param>
		/// <param name="y">Y coordinate of the point</param>
		public void ExpandTo(float x, float y)
		{
			if (x < MinX)
				MinX = x;
			if (x > MaxX)
				MaxX = x;

			if (y < MinY)
				MinY = y;
			if (y > MaxY)
				MaxY = y;
		}

	}
}
