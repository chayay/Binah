using System.Net;
using System.Web.Http;
using Binah.Siddur.TeffilahImporters;
using Binah.Web.Api;
using Binah.Web.Api.Controllers;
using Raven.Client.Embedded;
using Xunit;
using System.Linq;

namespace Binah.Tests.Unit.Web.Api.Controllers
{
	public class CanGetSiddurPrayer : RavenTest
	{
		[Fact]
		public void WillReturnTheCorrectPrayer()
		{
			var store = NewDocumentStore();
			using (var session = store.OpenSession())
			{
				new PrayerForTravelers().Import(new ImportData(session).Store);
				session.SaveChanges();
			}

			WaitForUserToContinueTheTest((EmbeddableDocumentStore) store);
			var controller = new SiddurController {RavenSession = store.OpenSession()};
			var prayer = controller.GetPrayer("Tefilat-HaDerech");

			Assert.Equal(1, prayer.Snippets.Count());
		}

		[Fact]
		public void WillReturn404ForNotExistsPrayer()
		{
			var store = NewDocumentStore();

			var controller = new SiddurController {RavenSession = store.OpenSession()};

			var exception = Assert.Throws<HttpResponseException>(() => controller.GetPrayer("Not-Exists"));
			Assert.Equal(HttpStatusCode.NotFound, exception.Response.StatusCode);
		}
	}
}