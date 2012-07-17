using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using AttributeRouting.Web.Http.WebHost;
using Binah.Web.Api.Controllers;

namespace Binah.Web.Api
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			RegisterRoutesUsingAttributeRouting(routes);

			routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			/*routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);*/
		}

		private static void RegisterRoutesUsingAttributeRouting(RouteCollection routes)
		{
			// See http://github.com/mccalltd/AttributeRouting/wiki for more options.
			// To debug routes locally using the built in ASP.NET development server, go to /routes.axd

			// ASP.NET Web API
			routes.MapHttpAttributeRoutes(configuration =>
			{
				configuration.ScanAssemblyOf<AbstractApiController>();
			});
		}
	}
}