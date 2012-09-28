﻿using System;
using System.Collections.Generic;
using Binah.Core.Models;
using System.Linq;

namespace Binah.Siddur.TeffilahImporters
{
	public class MorningBlessings : ISiddurPrayerImporter
	{
		public IEnumerable<SiddurPrayer> GetPrayers()
		{
			return new[]
			{
				new SiddurPrayer
				{
					Slug = "Birkot-HaShachar",
					NamesEn = new[] {"Morning Blessings", "Birkot HaShachar"},
					NamesHe = new[] {"ברכות השחר"},
					Snippets = new[]
					{
						"Al-Netilat-Yadayim",
						"Asher-Yatzar",
						"Elohai-Neshama",
						"HaNoten-LaSechvi-Binah",
						"Pokeiach-Ivrim",
						"Matir-Asurim",
						"...",
					}.Select(IdGenerator.ForSiddurSnippet).ToArray(),
				},
			};
		}

		public IEnumerable<SiddurSnippet> GetSnippets()
		{
			return new []
			{
				new SiddurSnippet
				{
					Slug = "Al-Netilat-Yadayim",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, אֲשֶׁר קִדְּשָׁנוּ בְּמִצְוֹתָיו, וְצִוָנוּ עַל נְטִילַת יָדָים:",
				},
				new SiddurSnippet
				{
					Slug = "Asher-Yatzar",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, אֲשֶׁר יָצַר אֶת הָאָדָם בְּחָכְמָה, וּבָרָא בוֹ נְקָבִים נְקָבִים, חֲלוּלִים חֲלוּלִים, גָּלוּי וְיָדוּעַ לִפְנֵי כִסֵּא כְבוֹדֶךָ, שֶׁאִם יִסָּתֵם אֶחָד מֵהֶם, אוֹ אִם יִפָּתֵחַ אֶחָד מֵהֶם, אִי אֶפְשַׁר לְהִתְקַיֵּם אֲפִילוּ שָׁעָה אֶחָת. בָּרוּךְ אַתָּה יְיָ רוֹפֵא כָל בָּשָׂר וּמַפְלִיא לַעֲשֹוֹת:",
				},
				new SiddurSnippet
				{
					Slug = "Elohai-Neshama",
					Content = "אֱלֹהַי, נְשָׁמָה שֶׁנָּתַתָּ בִּי טְהוֹרָה הִיא, אַתָּה בְרָאתָהּ, אַתָּה יְצַרְתָּהּ, אַתָּה נְפַחְתָּהּ בִּי, וְאַתָּה מְשַׁמְּרָהּ בְּקִרְבִּי, וְאַתָּה עָתִיד לִטְּלָהּ מִמֶּנִּי, וּלְהַחֲזִירָהּ בִּי לֶעָתִיד לָבֹא. כָּל זְמַן שֶׁהַנְּשָׁמָה בְּקִרְבִּי מוֹדֶה אֲנִי לְפָנֶיךָ יְיָ אֱלֹהַי וֵאלֹהֵי אֲבוֹתַי, רִבּוֹן כָּל הַמַּעֲשִׂים, אֲדוֹן כָּל הַנְּשָׁמוֹת: בָּרוּךְ אַתָּה יְיָ הַמַּחֲזִיר נְשָׁמוֹת לִפְגָרִים מֵתִים:",
				},

				new SiddurSnippet
				{
					Slug = "HaNoten-LaSechvi-Binah",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, הַנּוֹתֵן לַשֶֹּכְוִי בִינָה לְהַבְחִין בֵּין יוֹם וּבֵין לָיְלָה:",
				},
				new SiddurSnippet
				{
					Slug = "Pokeiach-Ivrim",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, פּוֹקֵחַ עִוְרִים:",
				},
				new SiddurSnippet
				{
					Slug = "Matir-Asurim",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, מַתִּיר אֲסוּרִים:",
				},
				new SiddurSnippet
				{
					Slug = "Zokef-Kfufim",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, זוֹקֵף כְּפוּפִים:",
				},
				new SiddurSnippet
				{
					Slug = "Malbish-Arumim",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, מַלְבִּישׁ עֲרֻמִּים:",
				},
				new SiddurSnippet
				{
					Slug = "Hanoten-LaYaef",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, הַנּוֹתֵן לַיָּעֵף כֹּחַ:",
				},
				new SiddurSnippet
				{
					Slug = "Roka-HaAretz",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, רוֹקַע הָאָרֶץ עַל הַמָּיִם:",
				},
				new SiddurSnippet
				{
					Slug = "Hamechin-Mitzaday-Gever",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, הַמֵּכִין מִצְעֲדֵי גָבֶר:",
				},
				new SiddurSnippet
				{
					Slug = "SheAsa-Li",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, שֶׁעָשָֹה לִּי כָּל צָרְכִּי:",
				},
				new SiddurSnippet
				{
					Slug = "Ozer-Yisrael",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, אוֹזֵר יִשְֹרָאֵל בִּגְבוּרָה:",
				},
				new SiddurSnippet
				{
					Slug = "Oter-Yisrael",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, עוֹטֵר יִשְׂרָאֵל בְּתִפְאָרָה:",
				},
				new SiddurSnippet
				{
					Slug = "Shelo-Asani-Goy",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, שֶׁלֹּא עָשַֹנִי גּוֹי:",
				},
				new SiddurSnippet
				{
					Slug = "Shelo-Asani-Aved",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, שֶׁלֹּא עָשַׂנִי עָבֶד:",
				},
				new SiddurSnippet
				{
					Slug = "Shelo-Asani-Isha",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, שֶׁלֹּא עָשַׂנִי אִשָּׁה:",
				},

				new SiddurSnippet
				{
					Slug = "HaMaavir-Shena",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, הַמַּעֲבִיר שֵׁנָה מֵעֵינָי וּתְנוּמָה מֵעַפְעַפָּי:",
				},
				new SiddurSnippet
				{
					Slug = "Vihi-Ratzon",
					Content = "וִיהִי רָצוֹן מִלְּפָנֶיךָ יְיָ אֱלֹהֵינוּ וֵאלֹהֵי אֲבוֹתֵינֹוּ, שֶׁתַּרְגִּילֵנוּ בְּתוֹרָתֶךָ, וְתַדְבִּיקֵנוּ בְּמִצְוֹתֶיךָ, וְאַל תְּבִיאֵנוּ לֹא לִידֵי חֵטְא וְלֹא לִידֵי עֲבֵרָה וְעָוֹן וְלֹא לִידֵי נִסָּיוֹן וְלֹא לִידֵי בִזָּיוֹן, וְאַל יִשְׁלוֹט בָּנוּ יֵצֶר הָרָע, וְהַרְחִיקֵנוּ מֵאָדָם רָע, וּמֵחָבֵר רָע, וְדַבְּקֵנוּ בְּיֵצֶר טֹוֹב וּבְמַעֲשִֹים טוֹבִים, וְכוֹף אֶת יִצְרֵנוּ לְהִשְׁתַּעְבֶּד לָךְ, וּתְנֵנוּ הַיּוֹם וּבְכָל יוֹם לְחֵן וּלְחֶסֶד וּלְרַחֲמִים בְּעֵינֶיךָ וּבְעֵינֵי כָל רוֹאֵינוּ, וְתִגְמְלֵנוּ חֲסָדִים טוֹבִים. בָּרוּךְ אַתָּה יְיָ הַגּוֹמֵל חֲסָדִים טוֹבִים לְעַמּוֹ יִשְׂרָאֵל:",
				},
				new SiddurSnippet
				{
					Slug = "Shetatzileini-Hayom",
					Content = "יְהִי רָצוֹןמִלְּפָנֶיךָ יְיָ אֱלֹהַי וֵאלֹהֵי אֲבוֹתַי שֶׁתַּצִּילֵנִי הַיּוֹם וּבְכָל יוֹם מֵעַזֵּי פָנִים, וּמֵעַזּוּת פָּנִים, מֵאָדָם רָע, וּמֵחָבֵר רָע, וּמִשָּׁכֵן רָע, וּמִפֶּגַע רָע, מֵעַיִן הָרָע, מִלָּשׁוֹן הָרָע, מִמַּלְשִׁינוּת, מֵעֵדוּת שֶׁקֶר מִשִּׂנְאַת הַבְּרִיּוֹת, מֵעֲלִילָה, מִמִּיתָה מְשֻׁנָּה, מֵחֳלָיִם רָעִים, מִמִּקְרִים רָעִים, וּמִשָֹּטָן הַמַּשְׁחִית מִדִּין קָשֶׁה, וּמִבַּעַל דִּין קָשֶׁה, בֵּין שֶׁהוּא בֶן בְּרִית, וּבֵין שֶׁאֵינוֹ בֶן בְּרִית. וּמִדִּינָהּ שֶׁל גֵּיהִנֹּם:",
				},

				new SiddurSnippet
				{
					Slug = "Al-Divray-Torah",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, אֲשֶׁר קִדְּשָׁנוּ בְּמִצְוֹתָיו, וְצִוָּנוּ עַל דִבְרֵי תוֹרָה:",
				},
				new SiddurSnippet
				{
					Slug = "VeHaarev-Na",
					Content = "וְהַעֲרֶב נָא יְיָ אֱלֹהֵינוּ אֶת דִּבְרֵי תוֹרָתְךָ בְּפִינוּ, וּבְפִי כָל עַמְּךָ בֵּית יִשְׂרָאֵל. וְנִהְיֶה אֲנַחְנוּ וְצֶאֱצָאֵינוּ, וְצֶאֱצָאֵי כָל עַמְּךָ בֵּית יִשְׂרָאֵל, כֻּלָּנוּ יוֹדְעֵי שְׁמֶךָ וְלוֹמְדֵי תוֹרָתֶךָ לִשְׁמָהּ. בָּרוּךְ אַתָּה יְיָ הַמְלַמֵּד תּוֹרָה לְעַמּוֹ יִשְׂרָאֵל:",
				},
				new SiddurSnippet
				{
					Slug = "Noten-HaTorah",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, אֲשֶׁר בָּחַר בָּנוּ מִכָּל הָעַמִּים, וְנָתַן לָנוּ אֶת תּוֹרָתוֹ. בָּרוּךְ אַתָּה יְיָ נוֹתֵן הַתּוֹרָה:",
				},
				new SiddurSnippet
				{
					Slug = "Koh-Tevarchu",
					Content = "וַיְדַבֵּריְיָ אֶל מֹשֶׁה לֵּאמֹר: דַּבֵּר אֶל אַהֲרֹן וְאֶל בָּנָיו לֵאמֹר, כֹּה תְבָרְכוּ אֶת בְּנֵי יִשְׂרָאֵל אָמוֹר לָהֶם:",
				},
				new SiddurSnippet
				{
					Slug = "Yevarechecha",
					Content = "יְבָרֶכְךָ יְיָ וְיִשְׁמְרֶךָ: יָאֵר יְיָ,פָּנָיו אֵלֶיךָ, וִיחֻנֶּךָּ: יִשָּׂא יְיָ, פָּנָיו אֵלֶיךָ, וְיָשֵׂם לְךָ שָׁלוֹם:",
				},
				new SiddurSnippet
				{
					Slug = "VeSamu",
					Content = "וְשָׂמוּ אֶת שְׁמִי עַל בְּנֵי יִשְׂרָאֵל וַאֲנִי אֲבָרְכֵם:",
				},
				new SiddurSnippet
				{
					Slug = "Eilu-Devarim",
					Content = "אֵלּוּ דְבָרִים שֶׁאֵין לָהֶם שִׁעוּר, הַפֵּאָה, וְהַבִּכּוּרִים, וְהָרְאָיוֹן, וּגְמִילוּת חֲסָדִים, וְתַלְמוּד תּוֹרָה: אֵלּוּ דְבָרִים שֶׁאָדָם אוֹכֵל פֵּרוֹתֵיהֶם בָּעוֹלָם הַזֶּה וְהַקֶּרֶן קַיֶּמֶת לָעוֹלָם הַבָּא, וְאֵלּוּ הֵן: כִּבּוּד אָב וָאֵם, וּגְמִילוּת חֲסָדִים, וְהַשְׁכָּמַת בֵּית הַמִּדְרָשׁ שַׁחֲרִית וְעַרְבִית, וְהַכְנָסַת אֹרְחִים וּבִקּוּר חוֹלִים, וְהַכְנָסַת כַּלָּה, וּלְוָיַת הַמֵּת, וְעִיּוּן תְּפִלָּה, וַהֲבָאַת שָׁלוֹם שֶׁבֵּין אָדָם לַחֲבֵרוֹ, וּבֵין אִישׁ לְאִשְׁתּוֹ, וְתַלְמוּד תּוֹרָה כְּנֶגֶד כֻּלָּם:",
				},
			};
		}
	}
}