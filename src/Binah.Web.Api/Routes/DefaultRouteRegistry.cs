using System.Web.Http;

namespace Binah.Web.Api.Routes
{
	public class DefaultRouteRegistry : IRouteRegistry
	{
		public void RegisterRoutes(HttpRouteCollection routes)
		{
			routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: null
				);
		}

		public int Priority
		{
			get { return int.MaxValue; }
		}
	}
}