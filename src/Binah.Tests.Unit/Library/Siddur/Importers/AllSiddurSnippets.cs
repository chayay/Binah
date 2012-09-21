using System.Collections;
using System.Collections.Generic;
using Binah.Core.Extensions;
using Binah.Core.Models;
using Binah.Siddur.TeffilahImporters;

namespace Binah.Tests.Unit.Library.Siddur.Importers
{
	public class AllSiddurSnippets : IEnumerable<object[]>
	{
		private int id;

		public IEnumerator<object[]> GetEnumerator()
		{
			var importers = typeof (ITeffilahImporter).Assembly.GetAllImplementorsOf<ITeffilahImporter>();
			var enumerator = importers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				var snippets = new List<SiddurSnippet>();
				enumerator.Current.Import(entity =>
				{
					entity.Id = entity.GetType().Name + "/" + ++id;

					var snippet = entity as SiddurSnippet;
					if (snippet != null)
					{
						snippets.Add(snippet);
					}

					return entity.Id;
				});
				foreach (var snippet in snippets)
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