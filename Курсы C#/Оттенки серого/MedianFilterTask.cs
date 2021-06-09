using System.Linq;
using System.Collections.Generic;

namespace Recognizer
{
	internal static class MedianFilterTask
	{
		/* 
		 * Для борьбы с пиксельным шумом, подобным тому, что на изображении,
		 * обычно применяют медианный фильтр, в котором цвет каждого пикселя, 
		 * заменяется на медиану всех цветов в некоторой окрестности пикселя.
		 * https://en.wikipedia.org/wiki/Median_filter
		 * 
		 * Используйте окно размером 3х3 для не граничных пикселей,
		 * Окно размером 2х2 для угловых и 3х2 или 2х3 для граничных.
		 */
		public static double[,] MedianFilter(double[,] original)
		{
			var matrix = new double[original.GetLength(0) + 2, original.GetLength(1) + 2];
			for (int i = 0; i < original.GetLength(0); i++)
				for (int j = 0; j < original.GetLength(1); j++)
					matrix[i + 1, j + 1] = original[i, j];
			var pointsAround = new List<double>();
			for (int i = 1; i < original.GetLength(0); i++)
			{
				for (int j = 1; j < original.GetLength(1); j++)
				{
					for (int m = i - 1; m < i + 2; m++)
					{
						for (int n = j - 1; n < j + 2; n++)
						{
							if (m != 0 && n != 0)
							{
								pointsAround.Add(matrix[m, n]);
							}
						}
					}
					original[i - 1, j - 1] = FindMedian(pointsAround);
					pointsAround.Clear();
				}
			}
			return original;
		}

		public static double FindMedian (List<double> pointsAround)
		{
			pointsAround.Sort();
			if (pointsAround.Count % 2 != 0)
				return pointsAround[pointsAround.Count / 2];
			else
				return (pointsAround[pointsAround.Count / 2 - 1] + pointsAround[pointsAround.Count / 2]) / 2;
		}
	}
}