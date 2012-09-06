namespace Binah.Core.Models
{
	public class User : Entity
	{
		public int IdentificationNumber { get; set; }
		public string Username { get; set; }
		public string ScreenName { get; set; }
		public string ForeName { get; set; }
		public string LastName { get; set; }
		public string NickName { get; set; }
		public string Email { get; set; }

		private UserPreference preference;
		public UserPreference Preference
		{
			get { return preference ?? (preference = new UserPreference()); }
			set { preference = value; }
		}
	}

	public class UserPreference
	{
		public string Language { get; set; }
	}

	public class UserAddress
	{
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zipcode { get; set; }
		public float Latitude { get; set; }
		public float Longitude { get; set; }
	}
}