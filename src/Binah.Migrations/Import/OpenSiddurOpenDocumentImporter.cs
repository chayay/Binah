using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using Binah.Core.Hebrew;
using Binah.Core.Extensions;
using Binah.Core.Models;
using Binah.Infrastructure.RavenDB;

namespace Binah.Migrations.Import
{
	public class OpenSiddurOpenDocumentImporter : IImporter
	{
		private const string OfficeXmlns = "urn:oasis:names:tc:opendocument:xmlns:office:1.0";
		private const string TextXmlns = "urn:oasis:names:tc:opendocument:xmlns:text:1.0";

		public static readonly Regex BibliographyReference = new Regex(@"^\d*\w* \d+:\d+(-\d+)?$", RegexOptions.Compiled);
		private readonly List<string> ignoredItems = new List<string>();
		private readonly List<string> shouldIgnoreItems = new List<string>();

		int importedSnippetsCount;

		public void Import()
		{
			new[]
			{
				/* 
				 * Done:
				 * "PrayerForTravelers",
				 * "MorningBlessing",
				 */

				"",

				/* 
				 * TODO:
				 * 
				// "BlessingBook",
				// "BedtimeShema",
				// "KiddushLevana",
				// "MorningBlessing",
				// "TikkunHatzot",
				// "HanukahBlessings",
				// "ShaharitMorning",
				// "ShaharitMusafShabbat",
				// "MinhahAfternoon",
				// "MinhahShabbatAfternoon",
				// "MaarivEvening",
				// "SefiratHaOmer",
				// "KiddushLevana",
				// "TheShabbatBook",
				// "TikkunHatzot",
				 * */
			}
				.ForEach(file =>
				{
					importedSnippetsCount = 0;
					var snippets = ImportFile(file);
					snippets = ConsolidateSnippets(snippets, file);
					WriteSnippetsToFile(snippets, file);
					AddItemsToDatabase(snippets);
				});
		}

		private List<SiddurSnippet> ImportFile(string name)
		{
			var snippets = new List<SiddurSnippet>();

			ignoredItems.Clear();
			shouldIgnoreItems.Clear();

			var document = XDocument.Load(string.Format(@"C:\Projects\OpenSiddurImport\NusahHaAri\{0}.xml", name));
			var body = document.Descendants(XName.Get("body", OfficeXmlns)).Single();
			var text = body.Descendants(XName.Get("text", OfficeXmlns)).Single();

			var resultItmes = new List<string>();
			var paragraphs = text.Descendants(XName.Get("p", TextXmlns)).ToArray();

			var version = paragraphs.First(element => element.Value.StartsWith("Version ")).Value;
			foreach (var paragraph in paragraphs)
			{
				var items = new List<string>();
				var textToIgnore = new List<string>();

				foreach (var node in paragraph.DescendantNodes())
				{
					var xElement = node as XElement;
					if (xElement != null)
					{
						if (xElement.Name.LocalName != "span")
						{
							textToIgnore.Add(xElement.Value);
							continue;
						}
						var span = xElement.Value;
						if (span == "")
							items.Add(" ");
						else if (IgnoreItem(span) == false)
						{
							items.Add(span);
						}
						continue;
					}

					var xText = node as XText;
					if (xText != null)
					{
						var value = xText.Value;
						var lastItem = items.LastOrDefault();
						if (lastItem == null)
						{
							items.Add(value);
						}
						else if (!lastItem.Contains(value) && !IgnoreItem(value) && !textToIgnore.Contains(value))
						{
							items.Add(value);
							textToIgnore.Clear();
						}
						continue;
					}

					throw new InvalidOperationException(node.GetType() + " is not recognized element.");
				}

				if (!items.Any(item => item.Any(c => c.IsVowel())))
					continue;
				
				var result = string.Join("", items);
				resultItmes.Add(result);
			}

			if (ignoredItems.Any())
				File.WriteAllLines(string.Format("zzz_IgnoredItems{0}.txt", name), ignoredItems.Distinct(), Encoding.UTF8);
			if (shouldIgnoreItems.Any())
				File.WriteAllLines(string.Format("ShouldIgnoreItems{0}.txt", name), shouldIgnoreItems.Distinct(), Encoding.UTF8);

			snippets.AddRange(TurnToEntities(resultItmes, version));
			Console.WriteLine("{0} items imported.", resultItmes.Count);

			return snippets;
		}

		private List<SiddurSnippet> ConsolidateSnippets(List<SiddurSnippet> snippets, string file)
		{
			var originalCount = snippets.Count;
			for (int i = 0; i < originalCount; i++)
			{
				var siddurSnippet = snippets[i];
				switch (DetermineWhatToDoWithItem(i + 1, file))
				{
					case ItemConsolidateAction.Remove:
						snippets[i] = null;
						break;
					case ItemConsolidateAction.MergeWithPrevious:
						var prevSnippet = snippets
							.Where(snippet => snippet != null)
							.Select(snippet => new {Index = int.Parse(snippet.Id), Snippet = snippet})
							.Where(arg => arg.Index < i + 1)
							.OrderByDescending(arg => arg.Index)
							.Select(x => x.Snippet )
							.First();

						prevSnippet.Content += " " + snippets[i].Content;
						snippets[i] = null;
						break;
				}
			}

			snippets = snippets.Where(snippet => snippet != null).ToList();
			return snippets;
		}

		private ItemConsolidateAction DetermineWhatToDoWithItem(int i, string file)
		{
			switch (file)
			{
				case "PrayerForTravelers":
					if (i == 1)
						return ItemConsolidateAction.Remove;
					if (i >= 3 && i <= 4)
						return ItemConsolidateAction.MergeWithPrevious;
					if (i >= 5 && i <= 8)
						return ItemConsolidateAction.Remove;
					
					break;
				case "MorningBlessing":
					if (i == 33)
						return ItemConsolidateAction.MergeWithPrevious;

					break;
				case "ShaharitMorning":
					if (i == 3)
						return ItemConsolidateAction.Remove;

					if (i >= 13 && i <= 34) // Ashrei
						return ItemConsolidateAction.MergeWithPrevious;

					if (i == 47)
						return ItemConsolidateAction.MergeWithPrevious;

					if (i >= 49 && i <= 50)
						return ItemConsolidateAction.MergeWithPrevious;

					if (i >= 54 && i <= 55)
						return ItemConsolidateAction.MergeWithPrevious;

					break;
			}

			return ItemConsolidateAction.LeaveAsIs;
		}

		private List<SiddurSnippet> TurnToEntities(List<string> items, string version)
		{
			var snippets = new List<SiddurSnippet>();
			foreach (var item in items)
			{
				var siddurSnippet = new SiddurSnippet
				{
					Id = (++importedSnippetsCount).ToString(CultureInfo.InvariantCulture),
					Content = item.Trim(),
				};
				Thread.Sleep(10);
				snippets.Add(siddurSnippet);
			}
			return snippets;
		}

		private void AddItemsToDatabase(List<SiddurSnippet> snippets)
		{
			using (var session = DocumentStoreHolder.OpenSession())
			{
				foreach (var siddurSnippet in snippets)
				{
					if (siddurSnippet.Slug == null)
						siddurSnippet.Id = "rawImport/SiddurSnippet/" + siddurSnippet.Id;
					else
					{
						siddurSnippet.Id = null;
					}

					session.Store(siddurSnippet);
				}
				session.SaveChanges();
			}
		}

		private void WriteSnippetsToFile(List<SiddurSnippet> snippets, string file)
		{
			var lines = snippets.Select(snippet => @"				new SiddurSnippet
				{
					Slug = """",
					Content = """ + snippet.Content + @""",
				},");

			File.WriteAllLines("snippets_" + file + ".cs", lines);
		}

		private bool IgnoreItem(string span)
		{
			if (new[] {"(", ")"}.Any(s => s == span))
				return true;

			if (BibliographyReference.IsMatch(span) && span.Length < 20)
			{
				ignoredItems.Add(span);
				return true;
			}

			var unicodeCategory = char.GetUnicodeCategory(span[0]);
			if (unicodeCategory == UnicodeCategory.LowercaseLetter 
				|| unicodeCategory == UnicodeCategory.UppercaseLetter)
			{
				shouldIgnoreItems.Add(span);
				return true;
			}

			return false;
		}
	}

	internal enum ItemConsolidateAction
	{
		Remove,
		LeaveAsIs,
		MergeWithPrevious
	}
}