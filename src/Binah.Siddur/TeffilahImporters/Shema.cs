using System;
using System.Collections.Generic;
using System.Linq;
using Binah.Core.Models;

namespace Binah.Siddur.TeffilahImporters
{
	public class Shema : ISiddurPrayerImporter
	{
		public IEnumerable<SiddurPrayer> GetPrayers()
		{
			return new[]
			{
				new SiddurPrayer
				{
					Slug = "Shema-Yisrael",
					NamesEn = new[] {"Shema Yisrael", "Sh'ma Yisrael"},
					NamesHe = new[] {"שמע ישראל"},
					Snippets = new[]
					{
						"Shema-Yisrael",
						"Baruch-Shem",
						"VeAhavta",
					}.Select(IdGenerator.ForSiddurSnippet).ToArray(),
				},
			};
		}

		public IEnumerable<SiddurSnippet> GetSnippets()
		{
			return new[]
			{
				new SiddurSnippet
				{
					Slug = "Shema-Yisrael",
					Content = "שְׁמַע | יִשְׂרָאֵל, יְיָ | אֱלֹהֵינוּ, יְיָ | אֶחָד:",
				},
				new SiddurSnippet
				{
					Slug = "Baruch-Shem",
					Content = "בָּרוּךְ שֵׁם כְּבוֹד מַלְכוּתוֹ לְעוֹלָם וָעֶד:",
				},
				new SiddurSnippet
				{
					Slug = "VeAhavta",
					Content = "וְאָהַבְתָּ אֵת יְיָ אֱלֹהֶיךָ, בְּכָל לְבָבְךָ, וּבְכָל נַפְשְׁךָ, וּבְכָל מְאֹדֶךָ: וְהָיוּ הַדְּבָרִים הָאֵלֶּה אֲשֶׁר אָנֹכִי מְצַוְּךָ הַיּוֹם עַל לְבָבֶךָ: וְשִׁנַּנְתָּם לְבָנֶיךָ וְדִבַּרְתָּ בָּם, בְּשִׁבְתְּךָ בְּבֵיתֶךָ, וּבְלֶכְתְּךָ בַדֶּרֶךְ, וּבְשָׁכְבְּךָ, וּבְקוּמֶךָ: וּקְשַׁרְתָּם לְאוֹת עַל יָדֶךָ, וְהָיוּ לְטֹטָפֹת בֵּין עֵינֶיךָ: וּכְתַבְתָּם עַל מְזֻזוֹת בֵּיתֶךָ וּבִשְׁעָרֶיךָ:",
				},
			};
		}
	}
}