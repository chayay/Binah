using System.Threading.Tasks;
using System.Web.Http;
using Binah.Core.Models;
using System.Linq;

namespace Binah.Web.Api.Controllers
{
	public class NewItemsController : AbstractApiController
	{
		public SiddurParagraph[] Get()
		{
			var newItems = RavenSession.Query<NewItemInserted>()
				.OrderBy(item => item.CreationDate)
				.Select(item => item.ItemId)
				.ToArray();

			var items = RavenSession.Load<object>(newItems);

			return items.Cast<SiddurParagraph>().ToArray();
		}
	}
}