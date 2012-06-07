using System.Linq;
using AttributeRouting.Web.Http;
using Binah.Core.Models;

namespace Binah.Web.Api.Controllers
{
	public class NewItemsController : AbstractApiController
	{
		[GET("api/new/items")]
		public SiddurParagraph[] Get()
		{
			var items = RavenSession.Advanced.LoadStartingWith<SiddurParagraph>("NewItemInserted/SiddurParagraph/", 0, 128)
				.OrderBy(item => item.CreationDate)
				.ToArray();

			return items;
		}
	}
}