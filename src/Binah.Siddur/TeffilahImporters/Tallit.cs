using System.Collections.Generic;
using System.Linq;
using Binah.Core.Models;

namespace Binah.Siddur.TeffilahImporters
{
	public class Tallit : ISiddurPrayerImporter
	{
		public IEnumerable<SiddurPrayer> GetPrayers()
		{
			return new[]
			{
				new SiddurPrayer
				{
					Slug = "Tallit",
					NamesEn = new[] {"Tallit", "Order of putting on the Tallit"},
					NamesHe = new[] {"טלית", "סדר לבישת טלית גדול"},
					Snippets = new[]
					{
						"Tallit-Barchi-Nafshi",
						"Tallit-LeHithatef",
						"Tallit-Ma-Yakar",
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
					Slug = "Tallit-Barchi-Nafshi",
					Content = "בָּרְכִי נַפְשִׁי אֶת יְיָ, יְיָ אֱלֹהַי גָּדַלְתָּ מְּאֹד, הוֹד וְהָדָר לָבָשְׁתָּ: עוֹטֶה אוֹר כַּשַּׂלְמָה, נוֹטֶה שָׁמַיִם כַּיְרִיעָה:",
				},
				new SiddurSnippet
				{
					Slug = "Tallit-LeHithatef",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, אֲשֶׁר קִדְּשָׁנוּ בְּמִצְוֹתָיו, וְצִוָּנוּ לְהִתְעַטֵּף בְּצִיצִית:",
				},
				new SiddurSnippet
				{
					Slug = "Tallit-Ma-Yakar",
					Content = "מַה יָּקָר חַסְדְּךָ אֱלֹהִים, וּבְנֵי אָדָם בְּצֵל כְּנָפֶיךָ יֶחֱסָיוּן: יִרְוְיֻן מִדֶּשֶׁן בֵּיתֶךָ וְנַחַל עֲדָנֶיךָ תַשְׁקֵם: כִּי עִמְּךָ מְקוֹר חַיִּים, בְּאוֹרְךָ נִרְאֶה אוֹר: מְשׁוֹךְ חַסְדְּךָ לְידְעֶיךָ וְצִדְקָתְךָ לְיִשְׁרֵי לֵב:",
				},
			};
		}
	}
}