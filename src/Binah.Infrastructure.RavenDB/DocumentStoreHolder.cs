﻿using System;
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
			conventions.TransformTypeTagNameToDocumentKeyPrefix = x => x; // Always use an UpperCase document keys.

			var generator = new MultiTypeHiLoKeyGenerator(Store, 1);
			Store.Conventions.DocumentKeyGenerator = entity => generator.GenerateDocumentKey(Store.Conventions, entity);
		}
	}
}