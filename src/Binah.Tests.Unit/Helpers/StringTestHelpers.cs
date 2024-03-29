using System;
using System.Globalization;
using System.IO;
using Xunit;

namespace Binah.Tests.Unit.Helpers
{
	public static class StringTestHelpers
	{
		public static void ShouldEqualWithDiff(this string actualValue, string expectedValue, DiffStyle diffStyle = DiffStyle.Full, TextWriter output = null)
		{
			if (actualValue == null || expectedValue == null)
			{
				Assert.Equal(expectedValue, actualValue);
				return;
			}

			if (output == null)
				output = Console.Out;

			if (actualValue.Equals(expectedValue, StringComparison.Ordinal)) return;

			output.WriteLine("Position\t Expected\t\t Actual");
			output.WriteLine("---------------------------------------------------------");
			int maxLen = Math.Max(actualValue.Length, expectedValue.Length);
			int minLen = Math.Min(actualValue.Length, expectedValue.Length);
			for (int i = 0; i < maxLen; i++)
			{
				if (diffStyle != DiffStyle.Minimal || i >= minLen || actualValue[i] != expectedValue[i])
				{
					output.WriteLine("{0,-3}{1}\t\t {2,-4} ({3,-3})\t\t {4,-4} ({5,-3} {6})",
					                 i, // the index
					                 i < minLen && actualValue[i] == expectedValue[i] ? " " : "*",		// put a mark beside a differing row
					                 i < expectedValue.Length ? expectedValue[i].ToSafeString() : "",	// character safe string
					                 i < expectedValue.Length ? HexChar(expectedValue[i]) : "",			// character decimal value
					                 i < actualValue.Length ? actualValue[i].ToSafeString() : "",		// character safe string
					                 i < actualValue.Length ? HexChar(actualValue[i]) : "",				// character decimal value
									 i < actualValue.Length ? CharUnicodeInfo.GetUnicodeCategory(actualValue[i]).ToString() : ""	// char Unicode category
						);
				}
			}
			output.WriteLine();
			output.Close();

			Assert.Equal(expectedValue, actualValue);
		}

		private static string HexChar(char c)
		{
			var num = (int) c;
			return string.Format(@"\u{0:X4}", num);
		}

		private static string ToSafeString(this char c)
		{
			if (Char.IsControl(c) || Char.IsWhiteSpace(c))
			{
				switch (c)
				{
					case '\r':
						return @"\r";
					case '\n':
						return @"\n";
					case '\t':
						return @"\t";
					case '\a':
						return @"\a";
					case '\v':
						return @"\v";
					case '\f':
						return @"\f";
					case '\u0020':
						return @"\s";
					default:
						return String.Format(@"\u{0:X};", (int) c);
				}
			}
			return c.ToString(CultureInfo.InvariantCulture);
		}

		public enum DiffStyle
		{
			Full,
			Minimal
		}
	}
}