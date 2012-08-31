using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Binah.Core.Models;
using Binah.Web.Api.ViewModels;

namespace Binah.Web.Api.Controllers
{
	public class SiddurController : AbstractApiController
	{
		[GET("api/siddur/{slug}")]
		public SiddurPrayerDto GetPrayer(string slug)
		{
			var prayer = RavenSession
				.Include<SiddurPrayer>(x => x.Snippets)
				.Load<SiddurPrayer>("SiddurPrayers/" + slug);
			if (prayer == null)
				throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

			return new SiddurPrayerDto
			{
				Name = prayer.NamesHe.FirstOrDefault(),
				Snippets = RavenSession.Load<SiddurSnippet>(prayer.Snippets),
			};
		}
	}
}