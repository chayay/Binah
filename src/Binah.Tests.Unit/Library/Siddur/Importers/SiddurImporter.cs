using Binah.Core.Models;
using Raven.Client;

namespace Binah.Tests.Unit.Library.Siddur.Importers
{
	public class SiddurImporter
	{
		private readonly IDocumentSession session;

		public SiddurImporter(IDocumentSession session)
		{
			this.session = session;
		}

		public string Store(Entity entity)
		{
			session.Store(entity);
			return entity.Id;
		}
	}
}