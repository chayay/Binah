using System.Collections.Generic;
using System.Linq;
using Binah.Core.Models;

namespace Binah.Siddur.TeffilahImporters
{
	public class Tefillin : ISiddurPrayerImporter
	{
		public IEnumerable<SiddurPrayer> GetPrayers()
		{
			return new[]
			{
				new SiddurPrayer
				{
					Slug = "Tefillin",
					NamesEn = new[] {"Tefillin", "Order of putting on the Tefillin"},
					NamesHe = new[] {"תפילין", "סדר הנחת תפילין"},
					Snippets = new[]
					{
						"Tefillin-LeHaniach",
						"Tefillin-Al-Mitzvat",
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
					Slug = "Tefillin-LeHaniach",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, אֲשֶׁר קִדְּשָׁנוּ בְּמִצְוֹתָיו, וְצִוָּנוּ לְהָנִיחַ תְּפִלִּין:",
				},
				new SiddurSnippet
				{
					Slug = "Tefillin-Al-Mitzvat",
					Content = "בָּרוּךְ אַתָּה יְיָ אֱלֹהֵינוּ מֶלֶךְ הָעוֹלָם, אֲשֶׁר קִדְּשָׁנוּ בְּמִצְוֹתָיו, וְצִוָּנוּ עַל מִצְוַת תְּפִלִּין:",
				},
			};
		}
	}
}