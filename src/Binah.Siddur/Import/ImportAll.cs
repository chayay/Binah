using System;
using Binah.Core.Extensions;
using Binah.Siddur.TeffilahImporters;

namespace Binah.Siddur.Import
{
	public static class ImportAll
	{
		public static void Execute(Action<object> store)
		{
			var importers = typeof (ISiddurPrayerImporter).Assembly.GetAllImplementorsOf<ISiddurPrayerImporter>();
			foreach (var importer in importers)
			{
				importer.GetSnippets().ForEach(store);
				importer.GetPrayers().ForEach(store);
			}
		}
	}
}