using System;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            double[,] matrix = new double[30, 12]; 
            string[] x = new string[30];
            string[] Y = new string[12];
            for (int i = 0; i < 30; i++)
                x[i] = (i + 2).ToString();
            for (int i = 0; i < 12; i++)
                Y[i] = (i + 1).ToString();
            int count = 0;
            for (int i = 2; i < 32; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    for (int k = 0; k < names.Length; k++)
                    {
                        if (names[k].BirthDate.Day == i && names[k].BirthDate.Month == j + 1)
                            count++;
                    }
                    matrix[i - 2, j] = count;
                    count = 0;
                }
            }

            return new HeatmapData(
                "Пример карты интенсивностей",
                matrix, 
                x, 
                Y);
        }
    }
}