using System;
using System.Collections.Generic;

namespace Recognizer
{
	public static class ThresholdFilterTask
	{
		public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
		{
			int rowCount = original.GetLength(0);
			int columnCount = original.GetLength(1);
			int pixelCount = rowCount * columnCount;
			int whitePixelCount = (int)(whitePixelsFraction * pixelCount);			
			var pixels = new List<double>();
			foreach (double pixel in original)
				pixels.Add(pixel);
			pixels.Sort();
			double t;
			if (whitePixelCount == 0)
			{
				for (int i = 0; i < rowCount; i++)
				{
					for (int j = 0; j < columnCount; j++)
					{
						original[i, j] = 0.0;
					}
				}
			}
			else
			{
				t = pixels[pixels.Count - whitePixelCount];
				for (int i = 0; i < rowCount; i++)
				{
					for (int j = 0; j < columnCount; j++)
					{
						if (original[i, j] >= t)
							original[i, j] = 1.0;
						else
							original[i, j] = 0.0;
					}
				}
			}		
			return original;
		}
	}
}