using System.Net.Http;
using System.Net.Http.Headers;
using Binah.Web.Api.Controllers;
using Xunit;
using Xunit.Extensions;

namespace Binah.Tests.Unit.Web.Api
{
	public class CanInferUsersLanguageFromUsersBrowser
	{
		[Theory] 
		[InlineData("en-US,en;q=0.8,he;q=0.6", "en-US")]
		[InlineData("he,en-US;q=0.8,en;q=0.6", "he")]
		[InlineData("", "en")]
		[InlineData(null, "en")]
		public void BasedOnAcceptLanguageHttpHeader(string acceptLanguage, string language)
		{
			var controller = new UserController();
			controller.Request = new HttpRequestMessage();
			controller.Request.Headers.Add("Accept-Language", acceptLanguage);

			var user = controller.GetUser();

			Assert.Equal(language, user.Preference.Language);
		}
	}
}