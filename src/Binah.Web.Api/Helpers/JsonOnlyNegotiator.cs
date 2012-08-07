using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Binah.Web.Api.Helpers
{
	public class JsonOnlyNegotiator : IContentNegotiator
	{
		public ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
		{
			var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
			json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			json.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

#if DEBUG
			json.SerializerSettings.Formatting = Formatting.Indented;
#else
			json.SerializerSettings.Formatting = Formatting.None;
#endif

			var result = new ContentNegotiationResult(json, new MediaTypeHeaderValue("application/json"));
			return result;
		}
	}
}