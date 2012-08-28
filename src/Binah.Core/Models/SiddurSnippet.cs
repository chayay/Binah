using System;

namespace Binah.Core.Models
{
	public class SiddurSnippet : Entity
	{
		public string Slug { get; set; }
		public string Content { get; set; }
		public bool IsProofreaded { get; set; }
	}
}