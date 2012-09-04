using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Binah.Core.Models;
using Binah.Siddur.TeffilahImporters;
using Binah.Tests.Unit.Helpers;
using Binah.Web.Api;
using Xunit;
using Xunit.Sdk;

namespace Binah.Tests.Unit.Library.Unicode
{
	public class NormalizationTests : RavenTest
	{
		[Fact]
		public void NormalizationToFormDIsDifferent()
		{
			var snippet = GetSnippet();
			var content = snippet.Content;
			var words = content.Split(' ');

			foreach (var word in words)
			{
				Console.WriteLine("Word: '{0}'", word);
				word.Normalize(NormalizationForm.FormD).ShouldEqualWithDiff(word);
			}

			Assert.Equal(content, content.Normalize(NormalizationForm.FormD));
		}

		[Fact]
		public void HebrewNormalizationShouldWork()
		{
			var snippet = GetSnippet();
			var content = snippet.Content;

			try
			{
				Assert.Equal(content, content.NormalizeHebrew());
			}
			catch (EqualException)
			{
				var words = content.Split(' ');
				foreach (var word in words)
				{
					Console.WriteLine("Word: '{0}'", word);
					word.NormalizeHebrew().ShouldEqualWithDiff(word);
				}
			}
		}

		private SiddurSnippet GetSnippet()
		{
			var store = NewDocumentStore();

			using (var session = store.OpenSession())
			{
				new PrayerForTravelers().Import(new ImportData(session).Store);
				session.SaveChanges();
			}

			using (var session = store.OpenSession())
			{
				return session.Load<SiddurSnippet>("SiddurSnippets/Tefilat-HaDerech");
			}
		}
	}
}