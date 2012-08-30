using System.Web.Http.Filters;
using Binah.Infrastructure.RavenDB;
using Binah.Web.Api.Controllers;

namespace Binah.Web.Api
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(HttpFilterCollection filters)
		{
			filters.Add(new RavenSessionManagementAttribute(DocumentStoreHolder.Store));
		}
	}
}