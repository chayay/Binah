using Binah.Core.Hebrew;
using Xunit;

namespace Binah.Tests.Unit.Library.Unicode
{
	public class TetragrammatonTests
	{
		[Fact]
		public void ShortTetragrammatonNiqqudShouldBeInTheRightOrder()
		{
			var s = Tetragrammaton.Short;
			Assert.Equal(3, s.Length);
			Assert.Equal(HebrewLetters.DoubleYod, s[0]);
			Assert.Equal(HebrewVowels.Sheva, s[1]);
			Assert.Equal(HebrewVowels.Qamats, s[2]);
		}
		
		[Fact]
		public void FullTetragrammatonNiqqudShouldBeInTheRightOrder()
		{
			var full = Tetragrammaton.Full;
			Assert.Equal(7, full.Length);
			Assert.Equal(HebrewLetters.Yod, full[0]);
			Assert.Equal(HebrewVowels.Sheva, full[1]);
			Assert.Equal(HebrewLetters.He, full[2]);
			Assert.Equal(HebrewVowels.HolamHaser, full[3]);
			Assert.Equal(HebrewLetters.Vav, full[4]);
			Assert.Equal(HebrewVowels.Qamats, full[5]);
			Assert.Equal(HebrewLetters.He, full[6]);
		}
	}
}