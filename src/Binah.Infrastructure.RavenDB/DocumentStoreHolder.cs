﻿using System;
using System.Reflection;
using Binah.Core.Models;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace Binah.Infrastructure.RavenDB
{
	public class DocumentStoreHolder
	{
		private static IDocumentStore store;
		public static IDocumentStore Store
		{
			get
			{
				if (store == null)
					throw new InvalidOperationException("Document store was not initialized yet.");
				return store;
			}
			set { store = value; }
		}

		public static void Initialize()
		{
			Store = new DocumentStore {Url = "http://localhost:3003", DefaultDatabase = "Binah"};
			SetupConventions(Store.Conventions);

			Store.Initialize();

			IndexCreation.CreateIndexes(Assembly.GetCallingAssembly(), Store);
		}

		public static IDocumentSession OpenSession()
		{
			var session = store.OpenSession();
			session.Advanced.UseOptimisticConcurrency = true;
			return session;
		}

		public static void SetupConventions(DocumentConvention conventions)
		{
			conventions.TransformTypeTagNameToDocumentKeyPrefix = typeTagName => typeTagName;

			conventions.RegisterIdConvention<SiddurSnippet>((commands, snippet) => string.Format("{0}/{1}", conventions.GetTypeTagName(snippet.GetType()), snippet.Slug));
			conventions.RegisterIdConvention<SiddurPrayer>((commands, prayer) => string.Format("{0}/{1}", conventions.GetTypeTagName(prayer.GetType()), prayer.Slug));
		}

		public static void Shutdown()
		{
			if (store != null && !store.WasDisposed)
				store.Dispose();
		}
	}
}