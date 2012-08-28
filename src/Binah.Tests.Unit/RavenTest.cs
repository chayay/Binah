using System;
using System.Collections.Generic;
using System.Linq;
using Binah.Core.Extensions;
using Raven.Client;
using Raven.Client.Embedded;

namespace Binah.Tests.Unit
{
	public class RavenTest : IDisposable
	{
		private readonly List<IDocumentStore> documentStores = new List<IDocumentStore>();

		protected IDocumentStore NewDocumentStore()
		{
			var store = new EmbeddableDocumentStore {RunInMemory = true}.Initialize();
			documentStores.Add(store);
			return store;
		}

		public void Dispose()
		{
			documentStores.Where(store => store != null)
				.ForEach(store => store.Dispose());
		}
	}
}