using System;
using System.Linq;
using Raven.Client;

namespace Binah.Infrastructure.RavenDB.Development
{
	public static class DevelopmentExtensions
	{
		 public static DevelopmentRefactoring Development(this IDocumentStore store)
		 {
			 return new DevelopmentRefactoring(store);
		 }
	}

	public class DevelopmentRefactoring
	{
		private readonly IDocumentStore store;

		public DevelopmentRefactoring(IDocumentStore store)
		{
			this.store = store;
		}

		public void LoadAndSave<T>(int batchSize = 1024, Action<T> action = null)
		{
			using (var session = store.OpenSession())
			{
				int skip = 0;
				while (true)
				{
					var items = session.Query<T>()
						.Skip(skip)
						.Take(batchSize)
						.ToList();
					skip += items.Count;

					if (action != null)
					{
						foreach (var item in items)
						{
							action(item);
						}
					}

					session.SaveChanges();

					if (items.Count == 0)
						break;
				}
			}
		}
	}
}