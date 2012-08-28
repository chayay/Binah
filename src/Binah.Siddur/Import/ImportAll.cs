using System;
using Binah.Core.Extensions;
using Binah.Core.Models;
using Binah.Siddur.TeffilahImporters;

namespace Binah.Siddur.Import
{
	public class ImportAll
	{
		private readonly Func<Entity, string> store;

		public ImportAll(Func<Entity, string> store)
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
				importer.Import(store);
			}
		}
	}
}