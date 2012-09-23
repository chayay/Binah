using System.Collections;
using System.Collections.Generic;
using Binah.Core.Extensions;
using Binah.Siddur.TeffilahImporters;

namespace Binah.Tests.Unit.Library.Siddur.Importers
{
	public class AllSiddurSnippets : IEnumerable<object[]>
	{
		public IEnumerator<object[]> GetEnumerator()
		{
			var importers = typeof (ISiddurPrayerImporter).Assembly.GetAllImplementorsOf<ISiddurPrayerImporter>();
			var enumerator = importers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				foreach (var snippet in enumerator.Current.GetSnippets())
				{
					yield return new object[] {snippet.Slug, snippet.Content};
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}