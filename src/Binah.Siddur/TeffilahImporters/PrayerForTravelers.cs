﻿using System.Collections.Generic;
using System.Linq;
using Binah.Core.Models;

namespace Binah.Siddur.TeffilahImporters
{
	public class PrayerForTravelers : ISiddurPrayerImporter
	{
		public IEnumerable<SiddurPrayer> GetPrayers()
		{
			return new[]
			{
				new SiddurPrayer
				{
					Slug = "Tefilat-HaDerech",
					NamesEn = new[] {"Prayer For Travelers", "Traveler's Prayer", "Wayfarer's Prayer", "Tefilat HaDerech"},
					NamesHe = new[] {"תפלת הדרך", "תפילת הדרך"},
					Snippets = new[] {"Tefilat-HaDerech"}.Select(IdGenerator.ForSiddurSnippet).ToArray(),
				},
			};
		}

		public IEnumerable<SiddurSnippet> GetSnippets()
		{
			return new[]
			{
				new SiddurSnippet
				{
					Slug = "Tefilat-HaDerech",
					Content = "יְהִי רָצוֹן מִלְפָנֶֽיךָ יְהֹוָה אֱלֹהֵֽינוּ וֵאלֹהֵי אֲבוֹתֵֽינוּ שֶׁתּוֹלִיכֵֽנוּ לְשָׁלוֹם וְתַצְעִידֵֽנוּ לְשָׁלוֹם וְתַדְרִיכֵֽנוּ לְשָׁלוֹם וְתִסְמְכֵֽנוּ לְשָׁלוֹם וְתַגִיעֵֽנוּ לִמְחוֹז חֶפְצֵֽנוּ לְחַיִּים וּלְשִֹמְחָה וּלְשָׁלוֹם וְתַחֲזִירֵֽנוּ לְשָׁלוֹם וְתַצִּילֵֽנוּ מִכַּף כָּל־אוֹיֵב וְאוֹרֵב וְלִסְטִים וְחַיּוֹת רָעוֹת בַּדֶּֽרֶךְ וּמִכָּל־פּוּרְעָנִיּוֹת הַמִּתְרַגְּשׁוֹת וּבָאוֹת לְעוֹלָם וְתִשְׁלַח בְּרָכָה בְּכָל־מַעֲשֵׂה יָדֵֽינוּ וְתִתְּנֵֽני לְחֵן וּלְחֶֽסֶד וּלְרַחֲמִים בְּעֵינֶֽיךָ וּבְעֵינֵי כָל־רוֹאֵֽינוּ וְתִגְמְלֵֽנוּ חֲסָדִים טוֹבִים וְתִשְׁמַע קוֹל תְּפִלָּתֵֽנוּ כִּי אַתָּה שׁוֹמֵֽעַ תְּפִלַּת כָּל־פֶּה׃ בָּרוּךְ אַתָּה יְהֹוָה שׁוֹמֵֽעַ תְּפִלָּה׃",
					IsProofreaded = true,
					SiddurTorahOrPages = new[] {41},
					SiddurTehillatHashemPages = new[] {86},
				},
			};
		}
	}
}