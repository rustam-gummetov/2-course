namespace Pluralize
{
	public static class PluralizeTask
	{
		public static string PluralizeRubles(int count)
		{
			if (count % 10 == 1 && count % 100 != 11)
				return "рубль";
			else if (count % 10 >= 2 && count % 10 <= 4 && (System.Math.Abs(count) > 12 || System.Math.Abs(count) < 14))
				return "рубля";
			else
				return "рублей";			
		}
	}
}