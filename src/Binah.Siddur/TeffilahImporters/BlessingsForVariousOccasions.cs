using System.Collections.Generic;
using System.Linq;
using Binah.Core.Models;

namespace Binah.Siddur.TeffilahImporters
{
	public class BlessingsForVariousOccasions : ISiddurPrayerImporter
	{
		public IEnumerable<SiddurPrayer> GetPrayers()
		{
			return new[]
			{
				new SiddurPrayer
				{
					Slug = "Birkot-HaShachar",
					NamesEn = new[] {"Blessings for various occasions"},
					NamesHe = new[] {"סדר ברכות"},
					Snippets = new[]
					{
						"...",
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
					Slug = "Gefen",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, בּוֹרֵא פְּרִי הַגָּפֶן:",
				},
				new SiddurSnippet
				{
					Slug = "Hamotzi-Lechem",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, הַמּוֹצִיא לֶחֶם מִן הָאָרֶץ:",
				},
				new SiddurSnippet
				{
					Slug = "Mezonot",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, בּוֹרֵא מִינֵי מְזוֹנוֹת:",
				},
				new SiddurSnippet
				{
					Slug = "Adama",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, בּוֹרֵא פְרִי הָאֲדָמָה:",
				},
				new SiddurSnippet
				{
					Slug = "HaEtz",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, בּוֹרֵא פְרִי הָעֵץ:",
				},
				new SiddurSnippet
				{
					Slug = "SheHakol",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, שְׁהַכֹל נִהְיָה בִּדְבָרוֹ:",
				},
				new SiddurSnippet
				{
					Slug = "SheHecheyanu",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, שֶׁהֶחֱיָנוּ וְקִיְמָנוּ וְהִגִּיעָנוּ לַזְמַן הַזֶּה:",
				},

				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, עֹשֶֹה מַעֲשֵֹה בְרֵאשִׁית:",
				},
				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, שֶׁכֹחוֹ וּגְבוּרָתוֹ מָלֵא עוֹלָם:",
				},
				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, זוֹכֵר הַבְּרִית וְנֶאֵֶמָן בִּבְרִיתוֹ וְקַיָּם בְּמַאֲמָרוֹ:",
				},
				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, הַטּוֹב וְהַמֵטִיב:",
				},
				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, דַּיַּן הָאֱמֶת:",
				},
				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, בּוֹרֵא מְינֵי בְשָֹמִים:",
				},

				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, אֲשֶׁר קִדְּשָׁנוּ בְּמִצְוֹתָיו וְצִוָנוּ לִקְבּוֹעַ מְזוּזָה:",
				},
				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, אֲשֶׁר קִדְּשָׁנוּ בְּמִצְוֹתָיו, וְצִוָנוּ עַל (טְבִלַת כֶּלִי:|טְבִלַת כֵּלִים:)",
				},
				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, אֲשֶׁר קִדְּשָׁנוּ בְּמִצְוֹתָיו, וְצִוָנוּ לְהַפְרִישׁ חַלָּה:",
				},
				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, שֶׁלוֹ חִסַּר בָּעוֹלָמוֹ דָּבָר, וּבָרָא בוֹ בְּרִיּוֹת טוֹבוֹת וְאִילָנוֹת טוֹבִים, לְהַנּוֹת בָּהֶם בְּנֵי אָדָם:",
				},

				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, אֲשֶׁר קִדְּשָׁנוּ בְּמִצְוֹתָיו וְצִוָנוּ לַעֲשׂוֹת מַעֲקֶה:",
				},
				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, שֶׁעָשָֹה אֶת הַיָּם הַגָּדוֹל:",
				},
				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, שֶכָּכָה לוֹ בָּעוֹלָמוֹ:",
				},
				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, מְֹשַֹנּה הַבְּרִיּוֹת:",
				},
				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, שֶׁחָלַק מֵחָכְמָוֹת לִירֵאָיו:",
				},
				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, שֶׁנָּתַן מֵחָכְמָתוֹ לְבָשָֹר וָדָם:",
				},
				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, שֶׁנָּתַן מִכְּבוֹדוֹ לְבָשָֹר וָדָם:",
				},
				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, חֲכַם הָרָזִים:",
				},
				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ רַחֲמָנָא מַלְכָּא דְעָלְמָא, דִי יַהֲבָךְ לָן, וְלָא יַהֲבָךְ לְעַפְרָא:",
				},
				new SiddurSnippet
				{
					Slug = "",
					Content = "בָּרוּךְ אַתָּה יְיָ אֶלֹהֵינוּ מֶלֶךְ הָעוֹלָם, דַּיַּן הָאֱמֶת:",
				},
			};
		}
	}
}