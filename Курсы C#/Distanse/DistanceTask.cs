using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
		// Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
			if ((x - ax) * (by - ay) == (bx - ax) * (y - ay) && ((x <= ax && x >= bx) || (x >= ax && x <= bx)) && ((y <= ay && y >= by) || (y >= ay && y <= by)))
				return 0;
			double lengthSection = Math.Sqrt((ax - bx) * (ax - bx) + (ay - by) * (ay - by));
			double distanceToA = Math.Sqrt((ax - x) * (ax - x) + (ay - y) * (ay - y));
			double distanceToB = Math.Sqrt((bx - x) * (bx - x) + (by - y) * (by - y));
			if (ax == bx && ay == by)
				return distanceToA;
			if (distanceToA == 0 || distanceToB == 0 || (distanceToA + distanceToB - lengthSection < 0.00001))
				return 0;
			double angleA = Math.Acos((distanceToA * distanceToA - distanceToB * distanceToB + lengthSection * lengthSection) / (2 * distanceToA * lengthSection));
			double angleB = Math.Acos((distanceToB * distanceToB + lengthSection * lengthSection - distanceToA * distanceToA) / (2 * distanceToB * lengthSection));
			if (Math.Abs(angleA - angleB) < 0.00001 && Math.Abs(distanceToA - distanceToB) < 0.00001)
				return distanceToA * Math.Sin(angleA);
			if (Math.Round(angleA + angleB) >= 90)
				if (distanceToA <= distanceToB)
				{
					if (distanceToA <= distanceToA * Math.Sin(angleA))
						return distanceToA;
					else
						return distanceToA * Math.Sin(angleA);
				}
				else
				{
					if (distanceToB <= distanceToA * Math.Sin(angleA))
						return distanceToB;
					else
						return distanceToA * Math.Sin(angleA);
				}
			else
				return Math.Min(distanceToA, distanceToB);
		}
	}
}