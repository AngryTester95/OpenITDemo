using System;
using System.Text;

namespace OpenITDemo.Tests
{
	public static class Generator
	{
		private readonly static Random Random = new Random();

		public static string Get(int countOfSymbols)
		{
			var stringBuilder = new StringBuilder(countOfSymbols);

			while (countOfSymbols-- > 0)
			{
				stringBuilder.Append(Random.Next(0, 9));
			}

			return stringBuilder.ToString();
		}
	}
}
