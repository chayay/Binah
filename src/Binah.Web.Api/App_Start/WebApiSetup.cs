using System.Net.Http.Formatting;
using System.Web.Http;
using Binah.Web.Api.Handlers;
using Binah.Web.Api.Helpers;

namespace Binah.Web.Api
{
	public static class WebApiSetup
	{
		public static void Setup()
		{
			// Remove XML formatter
			GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

			// We do not need the content negotiation right now. Just use JSON.
			GlobalConfiguration.Configuration.Services.Replace(typeof(IContentNegotiator), new JsonOnlyNegotiator());

			// Support CORS - when running locally only
			GlobalConfiguration.Configuration.MessageHandlers.Add(new CorsHandler());
		}
	}
}