using Binah.Tests.Unit.Helpers;
using Xunit;
using Xunit.Sdk;

namespace Binah.Tests.Unit.Library.Unicode
{
	public class UnicodeNormalizationTests
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
			// Should throw - and print a table of diff chars to the console
			Assert.Throws<EqualException>(() => AfterNormalization.ShouldEqualWithDiff(BeforeNormalization));
		}
	}
}