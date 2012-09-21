using System;
using System.Collections.Generic;
using Binah.Core.Models;

namespace Binah.Siddur.TeffilahImporters
{
	public class Kaddish : ITeffilahImporter
	{
		public void Import(Func<Entity, string> store)
		{
			store(new SiddurPrayer
			{
				Slug = "Hatzi-Kaddish",
				NamesEn = new[] {"Hatzi Kaddish", "Kaddish Le'ela", "Half Kaddish", "Readers Kaddish", "Kaddish", "Qaddish"},
				NamesHe = new[] {"חצי קדיש", "קדיש יהא שלמא רבא", "קדיש"},
			});

			store(new SiddurPrayer
			{
				Slug = "Kaddish-Yatom",
				NamesEn = new[] {"Kaddish Yatom", "Kaddish Yehe Shelama Rabba", "Orphan's Kaddish", "Kaddish Avelim", "Mourners' Kaddish", "Kaddish", "Qaddish"},
				NamesHe = new[] {"קדיש יתום", "קדיש יהא שלמא רבא", "קדיש אבלים", "קדיש"},
			});

			store(new SiddurPrayer
			{
				Slug = "Kaddish-Shalem",
				NamesEn = new[] {"Kaddish Shalem", "Kaddish Titkabbal", "Kaddish", "Qaddish"},
				NamesHe = new[] {"קדיש שלם", "קדיש תתקבל", "קדיש"},
			});

			store(new SiddurPrayer
			{
				Slug = "Kaddish-DeRabbanan",
				NamesEn = new[] {"Kaddish DeRabbanan", "Kaddish al Yisrael", "Kaddish", "Qaddish"},
				NamesHe = new[] {"קדיש דרבנן", "קדיש על ישראל", "קדיש"},
				Snippets = new[]
				{
					IdGenerator.ForSiddurSnippet("Kaddish-Yitgaddal"),
					IdGenerator.ForSiddurSnippet("Kaddish-Amen"),
					IdGenerator.ForSiddurSnippet("Kaddish-BeAlma"),
					IdGenerator.ForSiddurSnippet("Kaddish-BeChayekhon"),
					IdGenerator.ForSiddurSnippet("Kaddish-YeheShmeh-Kahal"),
					IdGenerator.ForSiddurSnippet("Kaddish-YeheShmeh"),
					IdGenerator.ForSiddurSnippet("Kaddish-LeElla"),

					IdGenerator.ForSiddurSnippet("Kaddish-AlYisrael"),
					IdGenerator.ForSiddurSnippet("Kaddish-YeheShlama"),
					IdGenerator.ForSiddurSnippet("Kaddish-OsehShalom"),
				},
			});

			store(new SiddurPrayer
			{
				Slug = "Kaddish-HaGadol",
				NamesEn = new[] {"Kaddish HaGadol", "Kaddish DeIthadata", "Kaddish", "Qaddish"},
				NamesHe = new[] {"קדיש הגדול", "קדיש דאתחדתא", "קדיש"},
			});
		}

		private string[] GetSnippets(Func<Entity, string> store)
		{
			var snippets = new List<string>
			{
				store(new SiddurSnippet
				{
					Slug = "Kaddish-Yitgaddal",
					Content = "יִתְגַּדַּל וְיִתְקַדַּשׁ שְׁמֵהּ רַבָּא:",
				}),
				store(new SiddurSnippet
				{
					Slug = "Kaddish-Amen",
					Content = "אָמֵן",
				}),
				store(new SiddurSnippet
				{
					Slug = "Kaddish-BeAlma",
					Content = "בְּעָלְמָא דִּי בְרָא כִרְעוּתֵהּ וְיַמְלִיךְ מַלְכוּתֵהּ, וְיַצְמַח פֻּרְקָנֵהּ וִיקָרֵב מְשִׁיחֵהּ:",
				}),
				store(new SiddurSnippet
				{
					Slug = "Kaddish-BeChayekhon",
					Content = "בְּחַיֵּיכוֹן וּבְיוֹמֵיכוֹן וּבְחַיֵּי דְכָל בֵּית יִשְׂרָאֵל, בַּעֲגָלָא וּבִזְמַן קָרִיב. וְאִמְרוּ אָמֵן:",
				}),
				store(new SiddurSnippet
				{
					Slug = "Kaddish-YeheShmeh-Kahal",
					Content = "יְהֵא שְׁמֵהּ רַבָּא מְבָרַךְ לְעָלַם וּלְעָלְמֵי עָלְמַיָּא, יִתְבָּרֵךְ:",
				}),
				store(new SiddurSnippet
				{
					Slug = "Kaddish-YeheShmeh",
					Content = "יְהֵא שְׁמֵהּ רַבָּא מְבָרַךְ לְעָלַם וּלְעָלְמֵי עָלְמַיָּא, יִתְבָּרֵךְ, וְיִשְׁתַּבַּח, וְיִתְפָּאֵר, וְיִתְרוֹמֵם, וְיִתְנַשֵּׂא, וְיִתְהַדָּר, וְיִתְעַלֶּה, וְיִתְהַלָּל, שְׁמֵהּ דְקֻדְשָׁא בְּרִיךְ הוּא:",
				}),
				store(new SiddurSnippet
				{
					Slug = "Kaddish-LeElla",
					Content = "לְעֵלָּא מִן כָּל בִּרְכָתָא וְשִׁירָתָא, תֻּשְׁבְּחָתָא וְנֶחֱמָתָא, דַּאֲמִירָן בְּעָלְמָא, וְאִמְרוּ אָמֵן:",
				}),

				store(new SiddurSnippet
				{
					Slug = "Kaddish-AlYisrael",
					Content = "עַל יִשְׂרָאֵל וְעַל רֵבָּנָן. וְעַל תַּלְמִידֵהוֹן וְעַל כָּל תַּלְמִידֵי תַלְמִידֵיהוֹן. וְעַל כָּל מָאן דְּעָסְקִין בְּאוֹרַיְתָא דִּי בְאַתְרָא הָדֵין וְדִי בְכָל אֲתַר וַאֲתַר. יְהֵא לְהוֹן וּלְכוֹן שׁלָמָא רַבָּא חִנָּא וְחִסְדָּא וְרַחֲמִין וְחַיִּין אֲרִיכִין וּמְזוֹנָא רְוִיחָא וּפוּרְקָנָא מִן קֳדָם אֲבוּהוֹן דְּבִשְׁמַיָּא וְאִמְרוּ אָמֵן:",
				}),
				store(new SiddurSnippet
				{
					Slug = "Kaddish-YeheShlama",
					Content = "יְהֵא שְׁלָמָה רבָּא מִן שְׁמַיָּא וְחַיִּים טוֹבִים עָלֵינוּ וְעַל כָּל יִשְֹרָאֵל, וְאִמְרוּ אָמֵן:",
				}),
				store(new SiddurSnippet
				{
					Slug = "Kaddish-OsehShalom",
					Content = "עשֶֹׁה שָׁלוֹם|הַשָּׁלוֹם בִּמְרוֹמָיו הוּא יַעֲשֶֹה שָׁלוֹם עָלֵינוּ וְעַל כָּל יִשְֹרָאֵל, וְאִמְרוּ אָמֵן:",
				}),
			};

			return snippets.ToArray();
		}
	}
}