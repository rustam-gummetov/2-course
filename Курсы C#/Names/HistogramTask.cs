using System;
using System.Linq;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            string[] x = new string[31];
            double[] countName = new double[31];
            for (int i = 0; i < 31; i++)
            {
                x[i] = (i + 1).ToString();
            }
            int countNameInDay = 0;
            for (int i = 2; i < 32; i++)
            {
                for (int j = 0; j < names.Length; j++)
                {
                    if (names[j].Name == name && names[j].BirthDate.Day == i)
                    {
                        countNameInDay++;
                    }
                }
                countName[i - 1] = countNameInDay;
                countNameInDay = 0;
            }
            return new HistogramData(
                string.Format("Рождаемость людей с именем '{0}'", name), 
                x, 
                countName);
        }
    }
}