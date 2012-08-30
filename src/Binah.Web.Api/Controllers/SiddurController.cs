using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Binah.Core.Models;

namespace Binah.Web.Api.Controllers
{
	public class SiddurController : AbstractApiController
	{
		[GET("api/siddur/{slug}")]
		public SiddurPrayer GetPrayer(string slug)
		{
			var prayer = RavenSession.Load<SiddurPrayer>("SiddurPrayers/" + slug);
			if (prayer == null)
				throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
			
			return prayer;
		}
	}
}