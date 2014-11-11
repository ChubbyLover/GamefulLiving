using UnityEngine;
using System.Collections;

namespace PolygonCollections
{
	public class Polygon
	{
		protected Vector2[] Coordinates;

		public Polygon(Vector2[] Coordinates)
		{
			this.Coordinates = Coordinates;
		}

		public Vector2[] GetCoordinates()
		{
			return Coordinates;
		}
		public Vector2 GetCoordinate(int i)
		{
			return Coordinates[i];
		}
	}
}
