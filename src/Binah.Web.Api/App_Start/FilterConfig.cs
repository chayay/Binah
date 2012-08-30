using System.Web;
using System.Web.Mvc;
using Binah.Infrastructure.RavenDB;
using Binah.Web.Api.Controllers;

namespace Binah.Web.Api
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
			filters.Add(new RavenSessionManagementAttribute(DocumentStoreHolder.Store));
		}
	}
}