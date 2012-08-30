using System.Web.Http;
using Raven.Client;

namespace Binah.Web.Api.Controllers
{
	public abstract class AbstractApiController : ApiController
	{
		public IDocumentSession RavenSession { get; set; }
	}
}