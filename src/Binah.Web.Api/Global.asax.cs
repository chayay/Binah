using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Binah.Infrastructure.RavenDB;

namespace Binah.Web.Api
{
	public class WebApiApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			WebApiSetup.Setup();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			CommonSetup.Setup();

			DocumentStoreHolder.Initialize();
		}
	}
}