using System.Web.Http;

namespace Binah.Web.Api.Routes
{
	public interface IRouteRegistry
	{
		void RegisterRoutes(HttpRouteCollection routes);
		int Priority { get; }
	}
}