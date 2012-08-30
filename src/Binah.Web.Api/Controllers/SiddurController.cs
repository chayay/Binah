using System.Net;
using System.Net.Http;
using System.Web.Http;
using Binah.Core.Models;

namespace Binah.Web.Api.Controllers
{
	public class SiddurController : AbstractApiController
	{
		public SiddurPrayer GetPrayer(string slug)
		{
			var prayer = RavenSession.Load<SiddurPrayer>("SiddurPrayers/" + slug);
			if (prayer == null)
				throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
			
			return prayer;
		}
	}
}