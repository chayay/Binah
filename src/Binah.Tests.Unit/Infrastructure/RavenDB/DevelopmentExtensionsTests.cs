using Binah.Infrastructure.RavenDB.Development;
using Raven.Client;
using Xunit;

namespace Binah.Tests.Unit.Infrastructure.RavenDB
{
	public class DevelopmentExtensionsTests : RavenTest
	{
		private readonly IDocumentStore store;

		public DevelopmentExtensionsTests()
		{
			store = NewDocumentStore();
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