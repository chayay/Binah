using System.Net.Http.Headers;
using Binah.Core.Models;
using System.Linq;
using Binah.Web.Api.ViewModels;

namespace Binah.Web.Api.Controllers
{
	public class UserController : AbstractApiController
	{
		public UserDto GetUser()
		{
			var user = new User();

			var acceptLanguage = Request.Headers.AcceptLanguage;
			var firstLang = acceptLanguage.FirstOrDefault() ?? new StringWithQualityHeaderValue("en");
			user.Preference.Language = firstLang.Value;

			return new UserDto {Preference = user.Preference};
		}

		public string PostRegister(RegistrationInput input)
		{
			return "Success";
		}

		public string PostAuthenticate(RegistrationInput input)
		{
			return "Success";
		}
	}
}