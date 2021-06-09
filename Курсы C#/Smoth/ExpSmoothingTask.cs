using System.Collections.Generic;

namespace yield
{
	public static class ExpSmoothingTask
	{
		public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
		{
			//Fix me!

			//List<DataPoint> expData = new List<DataPoint>();
			//var e1 = data.GetEnumerator();
			//e1.MoveNext();
			//var y = (1 - alpha) * (e1.Current.OriginalY) + alpha * (e1.Current.OriginalY);
			//yield return y;
			//while (e1.MoveNext())
			//{
			//	y = (1 - alpha) * y + alpha * (e1.Current.OriginalY);
			//	yield return y;
			//}

			var e1 = data.GetEnumerator();
			e1.MoveNext();
			if (e1.Current.X == 0)
			{
				e1.MoveNext();
				e1.Current.ExpSmoothedY = (1 - alpha) * (e1.Current.OriginalY) + alpha * (e1.Current.OriginalY);
				yield return (DataPoint)data;
			}
			else
			{
				e1.MoveNext();
				e1.Current.ExpSmoothedY = (1 - alpha) * e1.Current.ExpSmoothedY + alpha * (e1.Current.OriginalY);
				yield return (DataPoint)data;
			}

			//return data;
		}
	}
}