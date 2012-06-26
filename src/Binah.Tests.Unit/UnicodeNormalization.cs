using Xunit;
using Binah.Tests.Unit.Helpers;
using Xunit.Sdk;

namespace Binah.Tests.Unit
{
	public class UnicodeNormalization
	{
		private const string BeforeNormalization = "לְשֵׁם יִחוּד קֻדְשָׁא בְּרִיךְ הוּא וּשְׁכִינְתֵּהּ";
		private const string AfterNormalization = "לְשֵׁם יִחוּד קֻדְשָׁא בְּרִיךְ הוּא וּשְׁכִינְתֵּהּ";

		[Fact]
		public void TheyAreNotEqual()
		{
			Assert.NotEqual(BeforeNormalization, AfterNormalization);
		}

		[Fact]
		public void WhyTheyAreNotEqual()
		{
			try
			{
				AfterNormalization.ShouldEqualWithDiff(BeforeNormalization);
			}
			catch (EqualException)
			{
				/* Should throw - and print a table of diff chars to the console */
			}
		}
	}
}