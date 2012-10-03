using System.Web.Http;
using AttributeRouting.Web.Http.WebHost;

namespace Binah.Web.Api
{
	public class RouteConfig
	{
		public static void RegisterRoutes(HttpRouteCollection routes)
		{
			AttributeRoutingRegisterRoutes(routes);

			routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}

		private static void AttributeRoutingRegisterRoutes(HttpRouteCollection routes)
		{
			// See http://github.com/mccalltd/AttributeRouting/wiki for more options.
			// To debug routes locally using the built in ASP.NET development server, go to /routes.axd

			// ASP.NET Web API
			routes.MapHttpAttributeRoutes();
		}
	}
}