using System.Collections.Generic;
using System.Globalization;
using System.Text;

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