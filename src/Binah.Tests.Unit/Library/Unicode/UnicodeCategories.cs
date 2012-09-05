using System.Globalization;
using System.Linq;
using System.Reflection;
using Binah.Core.Hebrew;
using Xunit;

namespace Binah.Tests.Unit.Library.Unicode
{
	public class UnicodeCategories
	{
		[Fact]
		public void OtehrLetters()
		{
			var letters = typeof (HebrewLetters)
				.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
				.Where(info => info.IsLiteral && !info.IsInitOnly)
				.Select(info => (char) info.GetValue(null))
				.ToArray();

			foreach (var letter in letters)
			{
				var category = CharUnicodeInfo.GetUnicodeCategory(letter);
				Assert.Equal(UnicodeCategory.OtherLetter, category);
			}

			Assert.Equal(UnicodeCategory.OtherLetter, CharUnicodeInfo.GetUnicodeCategory(HebrewLetters.AlefLamed));
			Assert.Equal(UnicodeCategory.OtherLetter, CharUnicodeInfo.GetUnicodeCategory(HebrewLetters.DoubleVav));
			Assert.Equal(UnicodeCategory.OtherLetter, CharUnicodeInfo.GetUnicodeCategory(HebrewLetters.VavYod));
			Assert.Equal(UnicodeCategory.OtherLetter, CharUnicodeInfo.GetUnicodeCategory(HebrewLetters.DoubleYod));
		}

		[Fact]
		public void Niqqud()
		{
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.Qamats));
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.QamatsQatan));
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.Patach));
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.Zeire));
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.Segol));
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.Hiriq));
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.Sheva));
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.Kubutz));
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.HolamHaser));
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.HolamMale));
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.HatafQamatz));
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.HatafPatach));
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.HatafSegol));

			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.DageshOrMapiqOrShuruq));
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.Meteg));
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.ShinDot));
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.SinDot));
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.Rafe));

			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.MarkUpperDot));
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.MarkLowerDot));

			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(YiddishDigraph.CombiningGraphemeJoiner));

			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(YiddishDigraph.RingAbove));
			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(YiddishDigraph.DotAbove));
		}

		[Fact]
		public void Format()
		{
			Assert.Equal(UnicodeCategory.Format, CharUnicodeInfo.GetUnicodeCategory(YiddishDigraph.ZeroWidthJoiner));
		}

		[Fact]
		public void DashPunctuation()
		{
			Assert.Equal(UnicodeCategory.DashPunctuation, CharUnicodeInfo.GetUnicodeCategory(HebrewPunctuations.Maqaf));
		}

		[Fact]
		public void OtherPunctuation()
		{
			Assert.Equal(UnicodeCategory.OtherPunctuation, CharUnicodeInfo.GetUnicodeCategory(HebrewPunctuations.SofPasuq));
			Assert.Equal(UnicodeCategory.OtherPunctuation, CharUnicodeInfo.GetUnicodeCategory(Punctuations.Colon));
			Assert.Equal(UnicodeCategory.OtherPunctuation, CharUnicodeInfo.GetUnicodeCategory(HebrewVowels.Paseq));

			Assert.Equal(UnicodeCategory.OtherPunctuation, CharUnicodeInfo.GetUnicodeCategory(YiddishDigraph.NunHafukha));
			Assert.Equal(UnicodeCategory.OtherPunctuation, CharUnicodeInfo.GetUnicodeCategory(YiddishDigraph.YodWithHiriq));

			Assert.Equal(UnicodeCategory.OtherPunctuation, CharUnicodeInfo.GetUnicodeCategory(YiddishDigraph.BlackCircle));
		}

		[Fact]
		public void CantillationMarksAreNonSpacingMark()
		{
			var letters = typeof(CantillationMarks)
				.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
				.Where(info => info.IsLiteral && !info.IsInitOnly)
				.Select(info => (char)info.GetValue(null))
				.ToArray();

			foreach (var letter in letters)
			{
				var category = CharUnicodeInfo.GetUnicodeCategory(letter);
				Assert.Equal(UnicodeCategory.NonSpacingMark, category);
			}

			Assert.Equal(UnicodeCategory.NonSpacingMark, CharUnicodeInfo.GetUnicodeCategory(CantillationMarks.Darga));
		}
	}
}