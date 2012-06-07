using System.Web.Routing;
using AttributeRouting.Web.Http.WebHost;

namespace Binah.Web.Api
{
	public static class AttributeRoutingHttp
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			// See http://github.com/mccalltd/AttributeRouting/wiki for more options.
			// To debug routes locally using the built in ASP.NET development server, go to /routes.axd

			// ASP.NET Web API
			routes.MapHttpAttributeRoutes();
		}
	}
}