namespace Binah.Core.Models
{
	public class SiddurPrayer : Entity
	{
		public string Slug { get; set; }
		public string[] NamesEn { get; set; }
		public string[] NamesHe { get; set; }
		public string[] Snippets { get; set; }
		
		public bool IsRoot { get; set; }
	}
}