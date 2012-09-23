using Binah.Core.Models;
using Binah.Siddur.Import;
using Raven.Client;

namespace Binah.Web.Api
{
	public static class ImportData
	{
		public static void Import(IDocumentStore store)
		{
			using (var session = store.OpenSession())
			{
				var snippet = session.Load<SiddurSnippet>(IdGenerator.ForSiddurSnippet("Tefilat-HaDerech"));
				if (snippet != null)
					return;
				
				ImportAll.Execute(session.Store);
				session.SaveChanges();
			}
		}
	}
}