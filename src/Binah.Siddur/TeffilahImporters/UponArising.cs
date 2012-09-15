using System;
using System.Collections.Generic;
using Binah.Core.Models;

namespace Binah.Siddur.TeffilahImporters
{
	public class UponArising : ITeffilahImporter
	{
		public void Import(Func<Entity, string> store)
		{
			store(new SiddurPrayer
			{
				Slug = "Hashkamat-HaBoker",
				NamesEn = new[] {"Upon Arising", "Modeh Ani", "Hashkamat HaBoker"},
				NamesHe = new[] {"השכמת הבקר", "השכמת הבוקר", "מודה אני"},
				Snippets = GetSnippets(store),
			});
		}

		private string[] GetSnippets(Func<Entity, string> store)
		{
			var snippets = new List<string>
			{
				store(new SiddurSnippet
				{
					Slug = "Modeh-Ani",
					Content = "מוֹדֶה אֲנִי לְפָנֶיךָ מֶלֶךְ חַי וְקַיָּם, שֶׁהֶחֱזַרְתָּ בִּי נִשְׁמָתִי בְּחֶמְלָה. רַבָּה אֱמוּנָתֶךָ:",
					IsProofreaded = false,
					SiddurTorahOrPages = new[] {4},
					SiddurTehillatHashemPages = new[] {6},
				}),
			};

			return snippets.ToArray();
		}
	}
}