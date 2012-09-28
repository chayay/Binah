using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Binah.Core.Models;
using Binah.Web.Api.Dtos;
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

		[GET("api/siddur")]
		public IEnumerable<SiddurPrayerIcon> GetPrayers()
		{
			var prayers = RavenSession.Query<SiddurPrayer>()
				.Where(prayer => prayer.IsRoot)
				.ToArray();

			return prayers.Select(prayer => new SiddurPrayerIcon
			{
				Slug = prayer.Slug,
			});
		}
	}
}