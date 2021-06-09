using System;

namespace Recognizer
{
    internal static class SobelFilterTask
    {
        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {
            var rowCount = sx.GetLength(0);
            var columnCount = sx.GetLength(1);
            var sy = new double[rowCount, columnCount];
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    sy[j, i] = sx[i, j];
                }
            }
            var width = g.GetLength(0);
            var height = g.GetLength(1);
            var result = new double[width, height];
            for (int x = 1; x < width - 1; x++)
                for (int y = 1; y < height - 1; y++)
                {
                    // Вместо этого кода должно быть поэлементное умножение матриц sx и полученной транспонированием из неё sy на окрестность точки (x, y)
                    // Такая операция ещё называется свёрткой (Сonvolution)
                    //var gx =
                    //    -g[x - 1, y - 1] * sx[0, 0] - 2 * g[x, y - 1] * sx[1, 0] - g[x + 1, y - 1] * sx[2, 0]
                    //    + g[x - 1, y + 1] * sx[2, 0] + 2 * g[x, y + 1] * sx[2, 1] + g[x + 1, y + 1] * sx[2, 2];
                    //var gy =
                    //    -g[x - 1, y - 1] * sy[0, 0] - 2 * g[x - 1, y] * sy[0, 1] - g[x - 1, y + 1] * sy[0, 2]
                    //    + g[x + 1, y - 1] * sy[2, 0] + 2 * g[x + 1, y] * sy[2, 1] + g[x + 1, y + 1] * sy[2, 2];
                    //result[x, y] = Math.Sqrt(gx * gx + gy * gy);
                }
            return result;
        }
    }
}