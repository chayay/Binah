using System;
using System.Linq;
using Binah.Core.Extensions;
using Binah.Core.Hebrew;
using Binah.Core.Models;
using Binah.Siddur.TeffilahImporters;
using Binah.Tests.Unit.Helpers;
using Binah.Tests.Unit.Library.Unicode;
using Binah.Web.Api;
using Xunit;

namespace Binah.Tests.Unit.Library.Siddur.Importers
{
	public class PrayerForTravelersTests : RavenTest
	{
		[Fact]
		public void SnippetExists()
		{
			var snippet = GetSnippet();
			Assert.NotNull(snippet);
		}

		[Fact]
		public void ShouldContains62Words()
		{
			var content = GetSnippet().Content;
			Assert.NotNull(content);
			var words = content.Split(new[]{' '});
			words.ForEach(Console.WriteLine);
			Assert.Equal(62, words.Length);
		}

		[Fact]
		public void DoesNotContainANotRecognizedChar()
		{
			var content = GetSnippet().Content;
			foreach (var c in content)
			{
				HebrewUnicodeTextHelper.IsAHebrewRecognizedChar(c);
			}
		}

		[Fact]
		public void DoesNotContainDoubleYod()
		{
			var content = GetSnippet().Content;
			Assert.DoesNotContain("יְיָ", content);
			Assert.DoesNotContain(HebrewLetters.DoubleYod, content);
			Assert.DoesNotContain(Tetragrammaton.Short, content);
		}

		[Fact]
		public void ShouldContainTheFullTetragrammatonTwice()
		{
			var content = GetSnippet().Content;
			Assert.Equal(2, content.NumberOfOccurencies(Tetragrammaton.Full));
		}

		[Fact]
		public void HasSofPasuqTwice()
		{
			var content = GetSnippet().Content;
			Assert.Equal(2, content.NumberOfOccurencies(HebrewPunctuations.SofPasuq));
		}

		[Fact]
		public void HasMaqaf5Times()
		{
			var content = GetSnippet().Content;
			var doubleMaqafTimes = 1;
			Assert.Equal(5 + doubleMaqafTimes, content.NumberOfOccurencies(HebrewPunctuations.Maqaf));
			Assert.Equal(doubleMaqafTimes, content.NumberOfOccurencies(new string(HebrewPunctuations.Maqaf, 2)));
		}

		private SiddurSnippet GetSnippet()
		{
			return new PrayerForTravelers().GetSnippets().Single();
		}
	}
}