using System;
using System.Runtime.Serialization;
using System.Security;

namespace Binah.Tests.Unit.Library.Unicode
{
	[Serializable]
	public class InvalidHebrewUnicodeOrderException : Exception
	{
		public char[] InvalidPattern { get; set; }
		public char[] CorrectPattern { get; set; }

		public InvalidHebrewUnicodeOrderException()
		{
		}

		public InvalidHebrewUnicodeOrderException(string message) : base(message)
		{
		}

		public InvalidHebrewUnicodeOrderException(string message, Exception inner) : base(message, inner)
		{
		}

		// This constructor is needed for serialization.
		[SecuritySafeCritical]  // auto-generated
		protected InvalidHebrewUnicodeOrderException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		public InvalidHebrewUnicodeOrderException(char[] invalidPattern, char[] correctPattern)
		{
			InvalidPattern = invalidPattern;
			CorrectPattern = correctPattern;
		}
	}
}