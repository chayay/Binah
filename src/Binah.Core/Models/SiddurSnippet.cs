using System;

namespace Binah.Core.Models
{
	public class SiddurSnippet : Entity
	{
		public string Slug { get; set; }
		public string Content { get; set; }
		public bool IsProofreaded { get; set; }

		public int[] SiddurTorahOrPages { get; set; }
		public int[] SiddurTehillatHashemPages { get; set; }
	}

	public class WordReference
	{
		public int Index { get; set; }
		public string Word { get; set; }
		public string PreviousWord { get; set; }
		public string NextWord { get; set; }
	}
}