using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Binah.Core.Extensions;
using Binah.Infrastructure.RavenDB;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Database.Server;
using Raven.Json.Linq;

namespace Binah.Tests.Unit
{
	public class RavenTest : IDisposable
	{
		private readonly List<IDocumentStore> documentStores = new List<IDocumentStore>();

		protected IDocumentStore NewDocumentStore()
		{
			var store = new EmbeddableDocumentStore {RunInMemory = true};
			DocumentStoreHolder.SetupConventions(store.Conventions);
			store.Initialize();
			documentStores.Add(store);
			return store;
		}

		public void Dispose()
		{
			documentStores.Where(store => store != null)
				.ForEach(store => store.Dispose());
		}

		public static void WaitForUserToContinueTheTest(EmbeddableDocumentStore documentStore)
		{
			if (!Debugger.IsAttached)
				return;

			documentStore.DatabaseCommands.Put("Pls Delete Me", null,
			                                   RavenJObject.FromObject(new {StackTrace = new StackTrace(true)}),
			                                   new RavenJObject());

			documentStore.Configuration.AnonymousUserAccessMode = AnonymousUserAccessMode.All;
			using (var server = new HttpServer(documentStore.Configuration, documentStore.DocumentDatabase))
			{
				server.StartListening();
				Process.Start(documentStore.Configuration.ServerUrl); // start the server

				do
				{
					Thread.Sleep(100);
				} while (documentStore.DatabaseCommands.Get("Pls Delete Me") != null && (Debugger.IsAttached));
			}
		}
	}
}