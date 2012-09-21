using System;
using Xunit;

namespace Binah.Tests.Unit.Infrastructure.RavenDB
{
	public class DocumentIdPrefixShouldNotBeLowercased : RavenTest
	{
		[Fact]
		public void ForOneWordEntitiesName()
		{
			var store = NewDocumentStore();
			using (var session = store.OpenSession())
			{
				session.Store(new Simple());
				session.SaveChanges();
			}

			using (var session = store.OpenSession())
			{
				var item = session.Load<Entity>("Simples/1");
				Assert.NotNull(item);
				Assert.Equal("Simples", GetIdPrefix(item.Id));
			}
		}

		[Fact]
		public void ForMoreThanOneWordEntitiesName()
		{
			var store = NewDocumentStore();
			using (var session = store.OpenSession())
			{
				session.Store(new ComplexEntityName());
				session.SaveChanges();
			}

			using (var session = store.OpenSession())
			{
				var item = session.Load<Entity>("ComplexEntityNames/1");
				Assert.NotNull(item);
				Assert.Equal("ComplexEntityNames", GetIdPrefix(item.Id));
			}
		}

		private string GetIdPrefix(string id)
		{
			var prefix = id.Substring(0, id.IndexOf('/'));
			return prefix;
		}

		private class Entity
		{
			public string Id { get; set; }
		}

		private class ComplexEntityName : Entity
		{
		}

		private class Simple : Entity
		{
		}
	}
}