﻿using System;
using System.Collections.Generic;
using Binah.Core.Models;

namespace Binah.Siddur.TeffilahImporters
{
	public class PrayerForTravelers : ITeffilahImporter
	{
		public void Import(Func<Entity, string> store)
		{
			store(new SiddurPrayer
			{
				Slug = "Tefilat-HaDerech",
				NamesEn = new[] { "Prayer For Travelers", "Traveler's Prayer", "Wayfarer's Prayer", "Tefilat HaDerech" },
				NamesHe = new[] { "תפלת הדרך", "תפילת הדרך" },
				Snippets = GetSnippets(store),
			});
		}

		private string[] GetSnippets(Func<Entity, string> store)
		{
			var snippets = new List<string>
			{
				store(new SiddurSnippet
				{
					Slug = "Tefilat-HaDerech",
					Content = "יְהִי רָצוֹן מִלְפָנֶיךָ יְהֹוָה אֱלֹהֵינוּ וֵאלֹהֵי אֲבוֹתֵינוּ שֶׁתּוֹלִיכֵנוּ לְשָֹלוֹם וְתַצְעִידֵנוּ לְשָֹלוֹם וְתַדְרִיכֵנוּ לְשָֹלוֹם וְתִסְמְכֵנוּ לְשָֹלוֹם וְתַגִיעֵנוּ לִמְחוֹז חֶפְצֵנוּ לְחַיִּים וּלְשִֹמְחָה וּלְשָֹלוֹם וְתַחְזִירֵנוּ לְשָֹלוֹם וְתַצִּילֵנוּ מִכַּף כָּל אוֹיֵב וְאוֹרֵב וְלִסְטִים וְחַיּוֹת רָעוֹת בַדֶּרֶךְ וּמִכָּל פּוּרְעָנִיּוֹת הַמִתְרַגְּשׁוֹת וּבָאוֹת לָעוֹלָם וְתִשְלַח בְּרָכָה בְּכָל מַעֲשֵׂה יָדֵינוּ וְתִתְּנֵנוּ לְחֵן וּלְחֶסֶד וּלְרַחֲמִים בְעֵינֶיךָ וּבְעֵינֵי כָל רוֹאֵינוּ וְתִשְׁמַע קוֹל תְּפִלָּתֵנוּ כִּי אֵל שׁוֹמֵעַ תְּפִלָּה כָּל פֶּה׃ בָּרוּךְ אַתָּה יְהֹוָה שׁוֹמֵעַ תְּפִלָּה׃",
					SiddurTorahOrPages = new[] {41},
				}),
			};

			return snippets.ToArray();
		}
	}
}