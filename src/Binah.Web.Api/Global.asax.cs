using System.Web;
using System.Web.Http;
using Binah.Infrastructure.RavenDB;

namespace Binah.Web.Api
{
	public class WebApiApplication : HttpApplication
	{
		protected void Application_Start()
		{
			DocumentStoreHolder.Initialize();
			ImportData.Import(DocumentStoreHolder.Store);

			WebApiSetup.Setup(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalConfiguration.Configuration.Filters);
			RouteConfig.RegisterRoutes(GlobalConfiguration.Configuration.Routes);
			CommonSetup.Setup();
		}
	}
}