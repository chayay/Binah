using System.Web.Mvc;
using System.Web.Routing;
using Binah.Infrastructure.RavenDB;

namespace Binah.Web.Api
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			DocumentStoreHolder.Initialize();
		}
	}
}