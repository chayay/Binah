using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting.Web.Http;
using Binah.Core.Models;
using Binah.Infrastructure.RavenDB;
using Binah.Web.Api.ViewModel;
using Raven.Client.Linq;

namespace Binah.Web.Api.Controllers
{
	public class NewItemsController : AbstractApiController
	{
		[GET("api/new/items")]
		public NewSiddurParagraph[] Get(bool? saved, int size = 24)
		{
			var itemsQ = RavenSession.Query<SiddurSnippet>()
				.Customize(x => x.WaitForNonStaleResultsAsOfLastWrite());
	
			if (saved != true)
			{
				itemsQ = itemsQ.Where(item => item.Id.StartsWith("NewItemInserted/SiddurSnippet/"));
			}

			var items = itemsQ.OrderBy(item => item.CreationDate)
				.Take(size)
				.ToArray();
				
			return items
				.Select(paragraph => new NewSiddurParagraph { Content = paragraph.Content, Id = paragraph.Id, NewId = paragraph.Id, Revision = paragraph.Revision })
				.ToArray();
		}

		[DELETE("api/new/items")]
		public void Delete(string id)
		{
			var paragraph = RavenSession.Load<SiddurSnippet>(id);
			if (paragraph == null)
				throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));

			var equivalentSnippet = RavenSession.Query<SiddurSnippet>()
				.Customize(customization => customization.WaitForNonStaleResultsAsOfLastWrite())
				.FirstOrDefault(snippet => snippet.Content == paragraph.Content);

			if (equivalentSnippet == null || !equivalentSnippet.Id.StartsWith("siddurSnippets/"))
			{
				throw new InvalidOperationException(string.Format("Cannot delete {0} when there is no other document in the database with the same content", id));
			}

			RavenSession.Delete(paragraph);
		}

		[POST("api/new/items")]
		public SiddurSnippet Post(NewSiddurParagraph input)
		{
			if (input.NewId.StartsWith("siddurSnippets") || input.NewId.Contains("/"))
			{
				throw new InvalidOperationException(string.Format("Id should be partial. Id is: '{0}'", input.NewId));
			}
			if (input.NewId.Contains("'"))
			{
				throw new InvalidOperationException("Id cannot contain ' char");
			}

			SiddurSnippet snippet;
			using (var session = DocumentStoreHolder.Store.OpenSession())
			{
				snippet = session.Load<SiddurSnippet>(input.Id) ?? new SiddurSnippet();
			}
			snippet.Id = "siddurSnippets/" + input.NewId;
			RavenSession.Store(snippet);

			return snippet;
		}
	}
}