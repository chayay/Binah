using System;
using System.Collections.Generic;
using System.Linq;
using Binah.Core.Models;

namespace Binah.Siddur.TeffilahImporters
{
	public class UponArising : ISiddurPrayerImporter
	{
		public IEnumerable<SiddurPrayer> GetPrayers()
		{
			return new[]
			{
				new SiddurPrayer
				{
					Slug = "Hashkamat-HaBoker",
					NamesEn = new[] {"Upon Arising", "Modeh Ani", "Hashkamat HaBoker"},
					NamesHe = new[] {"השכמת הבקר", "השכמת הבוקר", "מודה אני"},
					Snippets = new[] {"Modeh-Ani"}.Select(IdGenerator.ForSiddurSnippet).ToArray(),
				},
			};
		}

		public IEnumerable<SiddurSnippet> GetSnippets()
		{
			return new[]
			{
				new SiddurSnippet
				{
					Slug = "Modeh-Ani",
					Content = "מוֹדֶה אֲנִי לְפָנֶיךָ מֶלֶךְ חַי וְקַיָּם, שֶׁהֶחֱזַרְתָּ בִּי נִשְׁמָתִי בְּחֶמְלָה. רַבָּה אֱמוּנָתֶךָ:",
					IsProofreaded = false,
					SiddurTorahOrPages = new[] {4},
					SiddurTehillatHashemPages = new[] {6},
				},
			};
		}
	}
}