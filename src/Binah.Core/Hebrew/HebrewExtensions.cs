using System.Linq;
using System.Reflection;

namespace Binah.Core.Hebrew
{
	public static class HebrewExtensions
	{
		public static bool IsVowel(this char c)
		{
			var constants = typeof (HebrewVowels)
				.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
				.Where(info => info.IsLiteral && !info.IsInitOnly);

			return constants.Any(info => (char)info.GetValue(null) == c);
		}

		public static bool IsHebrewLetter(this char c)
		{
			var constants = typeof (HebrewLetters)
				.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
				.Where(info => info.IsLiteral && !info.IsInitOnly);

			return constants.Any(info => (char)info.GetValue(null) == c);
		}

		public static bool IsEnglishLetter(this char c)
		{
			for (var letter = 'a'; letter <= 'Z'; letter++)
			{
				if (letter == c)
				{
					return true;
				}
			}
			return false;
		}
	}
}