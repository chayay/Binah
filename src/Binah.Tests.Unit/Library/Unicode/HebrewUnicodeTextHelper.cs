using Binah.Core.Hebrew;
using Xunit;

namespace Binah.Tests.Unit.Library.Unicode
{
	public class HebrewUnicodeTextHelper
	{
		public static void IsAHebrewRecognizedChar(char c)
		{
			Assert.True(HebrewLetters.IsHebrewLetter(c) ||
			            c.IsVowel() ||
			            c == HebrewPunctuations.SofPasuq ||
			            c == ' '
			            , string.Format(@"'{0}' is not a recognized char. Unicode: \u{1:X4}.", c, (int) c));
		}
	}
}