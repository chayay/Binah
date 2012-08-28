using System;
using Binah.Core.Extensions;
using Binah.Core.Models;
using Binah.Siddur.TeffilahImporters;

namespace Binah.Siddur.Import
{
	public class ImportAll
	{
		private readonly Action<Entity> store;

		public ImportAll(Action<Entity> store)
		{
			if (store == null)
				throw new ArgumentNullException("store");

			this.store = store;
		}

		public void Execute()
		{
			var importers = typeof (ITeffilahImporter).Assembly.GetAllImplementorsOf<ITeffilahImporter>();
			foreach (var importer in importers)
			{
				importer.Import(Store);
			}
		}

		private void Store(Entity entity)
		{
			if (string.IsNullOrWhiteSpace(entity.Id))
				throw new InvalidOperationException("Entitie's ID must be set explicitly on the entity.");

			store(entity);
		}
	}
}