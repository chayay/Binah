using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using Binah.Infrastructure.RavenDB;
using Raven.Abstractions.Exceptions;
using Raven.Client;

namespace Binah.Web.Api.Controllers
{
	public abstract class AbstractApiController : ApiController
	{
		protected IDocumentSession RavenSession { get; private set; }

		public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
		{
			RavenSession = DocumentStoreHolder.Store.OpenSession();
			RavenSession.Advanced.UseOptimisticConcurrency = true;

			return base.ExecuteAsync(controllerContext, cancellationToken)
				.ContinueWith(task =>
				{
					using (RavenSession)
					{
						if (task.Status != TaskStatus.Faulted && RavenSession != null)
						{
							try
							{
								RavenSession.SaveChanges();

							}
							catch (ConcurrencyException)
							{
								
								throw;
							}
						}
					}
					return task;
				}).Unwrap();
		}
	}
}