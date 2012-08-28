using System;
using Binah.Core.Hebrew;
using Binah.Core.Models;
using Binah.Siddur.Import;
using Xunit;
using Binah.Core.Extensions;

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
		public void ShouldContain67Words()
		{
			var content = GetSnippet().Content;
			Assert.NotNull(content);
			var words = content.Split(new[]{' '});
			words.ForEach(Console.WriteLine);
			Assert.Equal(67, words.Length);
		}

		[Fact]
		public void DoesNotContainsANotRecognizedChar()
		{
			var content = GetSnippet().Content;
			foreach (var c in content)
			{
				Assert.True(c == ' ' || c == ':' || c.IsHebrewLetter() || c.IsVowel(), string.Format(@"'{0}' is not a recognized char. Unicode: \u{1:X4}.", c, (int) c));
			}
		}

		private SiddurSnippet GetSnippet()
		{
			var store = NewDocumentStore();

			using (var session = store.OpenSession())
			{
				new ImportAll(entity =>
				{
					session.Store(entity);
					return entity.Id;
				}).Execute();
				session.SaveChanges();
			}
			
			using (var session = store.OpenSession())
			{
				return session.Load<SiddurSnippet>("SiddurSnippets/Tefilat-HaDerech");
			}
		}
	}
}