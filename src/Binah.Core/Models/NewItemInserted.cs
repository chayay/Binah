using System;

namespace Binah.Core.Models
{
	public class NewItemInserted : Entity
	{
		public string ItemId { get; set; }
		public DateTimeOffset CreationDate { get; set; }
	}
}