using System.Collections.Generic;
using Binah.Core.Models;

namespace Binah.Siddur.TeffilahImporters
{
	public interface ISiddurPrayerImporter
	{
		IEnumerable<SiddurPrayer> GetPrayers();
		IEnumerable<SiddurSnippet> GetSnippets();
	}
}