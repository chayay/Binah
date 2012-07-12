using Binah.Infrastructure.RavenDB.Development;
using Raven.Client;
using Raven.Client.Embedded;
using Xunit;

namespace Binah.Tests.Unit.Infrastructure.RavenDB
{
	public class DevelopmentExtensionsTests
	{
		private readonly IDocumentStore store;

		public DevelopmentExtensionsTests()
		{
			store = new EmbeddableDocumentStore { RunInMemory = true }.Initialize();
			using (var session = store.OpenSession())
			{
				session.Store(new Item {Id = "item/1"});
				session.SaveChanges();
			}
		}

		[Fact]
		public void CanRenameTheIdOfEntity()
		{
			store.Development();
		}

		private class Item
		{
			public string Id { get; set; }
		}
	}
}