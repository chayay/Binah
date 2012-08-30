using System.Net.Http.Formatting;
using System.Web.Http;
using Binah.Web.Api.Handlers;
using Binah.Web.Api.Helpers;

namespace Binah.Web.Api
{
	public static class WebApiSetup
	{
		public static void Setup(HttpConfiguration configuration)
		{
			// Remove XML formatter
			configuration.Formatters.Remove(configuration.Formatters.XmlFormatter);

			// We do not need the content negotiation right now. Just use JSON.
			configuration.Services.Replace(typeof(IContentNegotiator), new JsonOnlyNegotiator());

			// Support CORS - when running locally only
			configuration.MessageHandlers.Add(new CorsHandler());
		}
	}
}