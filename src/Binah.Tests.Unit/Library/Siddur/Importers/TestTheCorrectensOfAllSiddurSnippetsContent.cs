using System.Linq;
using Binah.Core.Hebrew;
using Xunit;
using Xunit.Extensions;

namespace Binah.Tests.Unit.Library.Siddur.Importers
{
	public class TestTheCorrectensOfAllSiddurSnippetsContent
	{
		[Theory]
		[ClassData(typeof(AllSiddurSnippets))]
		public void ShouldNotContainsMaqafTwice(string slug, string content)
		{
			Assert.DoesNotContain(new string(HebrewPunctuations.Maqaf, 2), content);
		}

		[Theory]
		[ClassData(typeof(AllSiddurSnippets))]
		public void EndsWithSofPasuq(string slug, string content)
		{
			Assert.Equal(HebrewPunctuations.SofPasuq, content.Last());
		}

		[Theory]
		[ClassData(typeof(AllSiddurSnippets))]
		public void TextDoesNotContainsColon_ShouldContainSofPasuqInstead(string slug, string content)
		{
			Assert.DoesNotContain(Punctuations.Colon, content);
		}

		[Theory]
		[ClassData(typeof(AllSiddurSnippets))]
		public void SlugsShouldNotBeEmpty(string slug, string content)
		{
			Assert.NotEmpty(slug);
		}

		[Theory]
		[ClassData(typeof(AllSiddurSnippets))]
		public void SlugsShouldNotContainASpace(string slug, string content)
		{
			Assert.DoesNotContain(' ', slug);
		}
	}
}