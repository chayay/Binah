using System;
using System.Collections.Generic;
using Binah.Core.Models;

namespace Binah.Siddur.TeffilahImporters
{
	public class Shema : ITeffilahImporter
	{
		public void Import(Func<Entity, string> store)
		{
			store(new SiddurPrayer
			{
				Slug = "Shema-Yisrael",
				NamesEn = new[] {"Shema Yisrael", "Sh'ma Yisrael"},
				NamesHe = new[] {"שמע ישראל"},
				Snippets = GetSnippets(store),
			});
		}

		private string[] GetSnippets(Func<Entity, string> store)
		{
			var snippets = new List<string>
			{
				store(new SiddurSnippet
				{
					Slug = "Shema-Yisrael",
					Content = "שְׁמַע | יִשְׂרָאֵל, יְיָ | אֱלֹהֵינוּ, יְיָ | אֶחָד:",
				}),
				store(new SiddurSnippet
				{
					Slug = "Baruch-Shem",
					Content = "בָּרוּךְ שֵׁם כְּבוֹד מַלְכוּתוֹ לְעוֹלָם וָעֶד:",
				}),
				store(new SiddurSnippet
				{
					Slug = "VeAhavta",
					Content = "וְאָהַבְתָּ אֵת יְיָ אֱלֹהֶיךָ, בְּכָל לְבָבְךָ, וּבְכָל נַפְשְׁךָ, וּבְכָל מְאֹדֶךָ: וְהָיוּ הַדְּבָרִים הָאֵלֶּה אֲשֶׁר אָנֹכִי מְצַוְּךָ הַיּוֹם עַל לְבָבֶךָ: וְשִׁנַּנְתָּם לְבָנֶיךָ וְדִבַּרְתָּ בָּם, בְּשִׁבְתְּךָ בְּבֵיתֶךָ, וּבְלֶכְתְּךָ בַדֶּרֶךְ, וּבְשָׁכְבְּךָ, וּבְקוּמֶךָ: וּקְשַׁרְתָּם לְאוֹת עַל יָדֶךָ, וְהָיוּ לְטֹטָפֹת בֵּין עֵינֶיךָ: וּכְתַבְתָּם עַל מְזֻזוֹת בֵּיתֶךָ וּבִשְׁעָרֶיךָ:",
				}),
			};

			return snippets.ToArray();
		}
	}
}