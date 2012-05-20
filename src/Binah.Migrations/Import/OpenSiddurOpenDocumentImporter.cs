using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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

		public void Import()
		{
			new []
			{
				"ShaharitMorning",
				"ShaharitMusafShabbat",
				"MinhahAfternoon",
				"MinhahShabbatAfternoon",
				"MaarivEvening",
				"SefiratHaOmer",
				"KiddushLevana",
				"TheBedtimeShema",
				"TheBlessingBook",
				"TheShabbatBook",
				"TikkunHatzot",
			}
				.ForEach(ImportFile);
		}

		private void ImportFile(string name)
		{
			ignoredItems.Clear();
			shouldIgnoreItems.Clear();

			var document = XDocument.Load(string.Format(@"C:\Projects\OpenSiddurImport\NusahHaAri\{0}.xml", name));
			var body = document.Descendants(XName.Get("body", OfficeXmlns)).Single();
			var text = body.Descendants(XName.Get("text", OfficeXmlns)).Single();

			var items = new List<string>();
			var paragraphs = text.Descendants(XName.Get("p", TextXmlns)).ToArray();

			var version = paragraphs.First(element => element.Value.StartsWith("Version ")).Value;
			foreach (var paragraph in paragraphs)
			{
				var builder = new StringBuilder();
				var spans = paragraph.Descendants(XName.Get("span", TextXmlns))
					.Select(span => span.Value)
					.ToArray();
				if (!spans.Any(span => span.Any(c => c.IsVowel())))
					continue;
				foreach (var span in spans)
				{
					if (span == "")
						builder.Append(' ');
					else if (IgnoreItem(span) == false)
					{
						builder.Append(span);
					}
				}
				var item = builder.ToString();
				//item = item.Remove(item.Length - 1, 1);
				items.Add(item);
			}

			if (ignoredItems.Any())
				File.WriteAllLines(string.Format("zzz_IgnoredItems{0}.txt", name), ignoredItems.Distinct(), Encoding.UTF8);
			if (shouldIgnoreItems.Any())
				File.WriteAllLines(string.Format("ShouldIgnoreItems{0}.txt", name), shouldIgnoreItems.Distinct(), Encoding.UTF8);

			AddItemsToDatabase(items, version);
		}

		private void AddItemsToDatabase(List<string> items, string version)
		{
			using (var session = DocumentStoreHolder.Store.OpenSession())
			{
				foreach (var item in items)
				{
					var siddurParagraph = new SiddurParagraph
					{
						Content = item,
						CreationDate = DateTimeOffset.Now,
						Revision = 1,
						Type = SiddurType.TorahOr,
						Comment = string.Format("Imported from the OpenSiddur Project. Version: '{{0}}'.{0}", version),
					};
					session.Store(siddurParagraph);
					session.Store(new NewItemInserted
					{
						ItemId = siddurParagraph.Id,
						CreationDate = DateTimeOffset.Now,
					});
				}
				session.SaveChanges();
			}
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
}