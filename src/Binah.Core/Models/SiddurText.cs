using System;

namespace Binah.Core.Models
{
	public class SiddurText : Entity
	{
		public string Content { get; set; }
		public bool IsProofreaded { get; set; }
		public SiddurType Type { get; set; }

		public DateTimeOffset CreationDate { get; set; }
		public int Revision { get; set; }
		public string Comment { get; set; }
	}

	[Flags]
	public enum SiddurType
	{
		None = 0,
		TorahOr = 1,
		TehillatHashem = 2,
	}
}