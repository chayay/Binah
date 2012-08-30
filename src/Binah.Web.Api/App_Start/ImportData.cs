using Binah.Core.Models;
using Binah.Infrastructure.RavenDB;
using Binah.Siddur.Import;
using Raven.Client;

namespace Binah.Web.Api
{
	public class ImportData
	{
		private readonly IDocumentSession session;

		public ImportData(IDocumentSession session)
		{
			this.session = session;
		}

		public void Import()
		{
			using (var session = DocumentStoreHolder.OpenSession())
			{
				var prayer = session.Load<SiddurPrayer>("SiddurPrayers/Tefilat-HaDerech");
				if (prayer != null)
					return;

				new ImportAll(Store).Execute();
			}
		}

		public string Store(Entity entity)
		{
			session.Store(entity);
			return entity.Id;
		}
	}
}