using System;
using System.Linq;

namespace Binah.Tests.Unit.Helpers
{
	public static class StringExtensions
	{
		public static int NumberOfOccurencies(this string str, string substring)
		{
			int count = 0, i = 0;

			while ((i = str.IndexOf(substring, i, StringComparison.InvariantCulture)) != -1)
			{
				i += substring.Length;
				++count;
			}

			return count;
		}

		public static int NumberOfOccurencies(this string str, char c)
		{
			return str.Count(f => f == c);
		}
	}
}