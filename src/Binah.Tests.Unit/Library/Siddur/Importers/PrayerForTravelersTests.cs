using Binah.Core.Models;
using Binah.Siddur.Import;
using Xunit;
using Binah.Core.Hebrew;

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

		private SiddurSnippet GetSnippet()
		{
			var store = NewDocumentStore();

			using (var session = store.OpenSession())
			{
				new ImportAll(session.Store).Execute();
				session.SaveChanges();
			}
			
			using (var session = store.OpenSession())
			{
				return session.Load<SiddurSnippet>("Tefilat-HaDerech");
			}
		}
	}
}