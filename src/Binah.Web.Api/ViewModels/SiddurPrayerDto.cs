using System.Collections.Generic;
using Binah.Core.Models;

namespace Binah.Web.Api.ViewModels
{
	public class SiddurPrayerDto
	{
		public string Name { get; set; }
		public IEnumerable<SiddurSnippet> Snippets { get; set; }
	}
}