namespace Binah.Core.Models
{
	public static class IdGenerator
	{
		public static string ForSiddurSnippet(string slug)
		{
			return "SiddurSnippets/" + slug;
		}
	}
}