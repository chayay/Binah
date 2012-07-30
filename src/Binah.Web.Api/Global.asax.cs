using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Binah.Infrastructure.RavenDB;
using Binah.Web.Api.Handlers;
using Binah.Web.Api.Helpers;

namespace Binah.Web.Api
{
	public class WebApiApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			CommonSetup.Setup();

			GlobalConfiguration.Configuration.Services.Replace(typeof(IContentNegotiator), new JsonOnlyNegotiator());
			GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsHandler());

			DocumentStoreHolder.Initialize();
		}
	}
}