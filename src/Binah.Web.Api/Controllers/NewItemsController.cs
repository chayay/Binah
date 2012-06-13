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
			var items = RavenSession.Query<SiddurParagraph>()
				.Customize(x => x.WaitForNonStaleResultsAsOfNow())
				.Where(item => item.Id.StartsWith("NewItemInserted/SiddurParagraph/"))
				.OrderBy(item => item.CreationDate)
				.ToArray();

			return items;
		}

		[POST("api/new/items")]
		public SiddurParagraph Post(SiddurParagraph paragraph)
		{
			return paragraph;
		}
	}
}