using System.Collections.Generic;
using System.Linq;
using Binah.Core.Models;

namespace Binah.Siddur.TeffilahImporters
{
	public class Tzitzit : ISiddurPrayerImporter
	{
		public IEnumerable<SiddurPrayer> GetPrayers()
		{
			return new[]
			{
				new SiddurPrayer
				{
					Slug = "Tzitzit",
					NamesEn = new[] {"Tzitzit", "Blessing on the Tzitzit"},
					NamesHe = new[] {"ציצית", "ברכה על הציצית"},
					Snippets = new[] {"Tzitzit"}.Select(IdGenerator.ForSiddurSnippet).ToArray(),
				},
			};
		}

		public IEnumerable<SiddurSnippet> GetSnippets()
		{
			return new []
			{
				new SiddurSnippet
				{
					Slug = "Tzitzit",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, אֲשֶׁר קִדְּשָׁנוּ בְּמִצְוֹתָיו, וְצִוָּנוּ עַל מִצְוַת צִיצִית:",
				},
			};
		}
	}
}