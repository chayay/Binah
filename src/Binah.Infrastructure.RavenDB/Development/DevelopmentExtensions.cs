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

		public void LoadAndSave<T>()
		{
			using (var session = store.OpenSession())
			{
				int skip = 0;
				const int take = 1024;
				while (true)
				{
					var builds = session.Query<T>()
						.Skip(skip)
						.Take(take)
						.ToList();
					skip += builds.Count;

					session.SaveChanges();

					if (builds.Count == 0)
						break;
				}
			}
		}
	}
}