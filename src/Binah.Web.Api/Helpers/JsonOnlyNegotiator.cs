using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace Binah.Web.Api.Helpers
{
	public class JsonOnlyNegotiator : IContentNegotiator
	{
		public ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
		{
			var result = new ContentNegotiationResult(new JsonMediaTypeFormatter(), new MediaTypeHeaderValue("application/json"));
			return result;
		}
	}
}