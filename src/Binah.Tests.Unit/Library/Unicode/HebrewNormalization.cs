using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Binah.Core.Hebrew;

namespace Binah.Tests.Unit.Library.Unicode
{
	public static class HebrewNormalization
	{
		public static string NormalizeHebrew(this string content)
		{
			List<char> niqqud = null;

			var builder = new StringBuilder();
			foreach (var c in content.Normalize(NormalizationForm.FormD))
			{
				var category = CharUnicodeInfo.GetUnicodeCategory(c);
				if (IsBaseConsonant(category) ||
					category == UnicodeCategory.SpaceSeparator)
				{
					niqqud = null;
					builder.Append(c);
				}
				else if (category == UnicodeCategory.NonSpacingMark)
				{
					if (niqqud == null)
						niqqud = new List<char>();
					builder.Append(c);
				}
				else if(category == UnicodeCategory.OtherPunctuation)
				{
					if (c == Punctuations.Colon)
						builder.Append(HebrewPunctuations.SofPasuq);
				}
				else if (category == UnicodeCategory.DashPunctuation)
				{
					if (c == HebrewPunctuations.Maqaf)
						builder.Append(c);
				}
				else
				{
					throw new InvalidOperationException(string.Format("Char: '{0}'.  Unicode: 'U+{1:X4}'. Category: '{2}'. Content: '{3}'.", c, (int)c, category, content));
				}
			}

			return builder.ToString();
		}

		public static bool IsBaseConsonant(UnicodeCategory category)
		{
			return category == UnicodeCategory.OtherLetter ||
			       category == UnicodeCategory.LowercaseLetter ||
			       category == UnicodeCategory.UppercaseLetter;
		}
	}
}