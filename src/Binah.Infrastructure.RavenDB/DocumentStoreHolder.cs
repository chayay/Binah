using System;
using System.Reflection;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace Binah.Infrastructure.RavenDB
{
	public class DocumentStoreHolder
	{
		private static IDocumentStore _store;
		public static IDocumentStore Store
		{
			get
			{
				if (_store == null)
					throw new InvalidOperationException("Document store was not initialized yet.");
				return _store;
			}
			set { _store = value; }
		}

		public static void Initialize()
		{
			Store = new DocumentStore {Url = "http://localhost:8080", DefaultDatabase = "Binah"};
			SetupConventions(Store.Conventions);

			Store.Initialize();

			IndexCreation.CreateIndexes(Assembly.GetCallingAssembly(), Store);
		}

		private static void SetupConventions(DocumentConvention conventions)
		{
			var generator = new MultiTypeHiLoKeyGenerator(Store, 1);
			conventions.DocumentKeyGenerator = entity => generator.GenerateDocumentKey(conventions, entity);
		}

		public static void Shutdown()
		{
			if (_store != null && !_store.WasDisposed)
				_store.Dispose();
		}
	}
}