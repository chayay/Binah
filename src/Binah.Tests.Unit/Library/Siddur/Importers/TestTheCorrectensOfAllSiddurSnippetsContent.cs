using System;
using Binah.Core.Hebrew;
using Binah.Core.Models;
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
		public void SlugsShouldNotBeEmpty(string slug, string content)
		{
			Assert.NotEmpty(slug);
		}
	}
}