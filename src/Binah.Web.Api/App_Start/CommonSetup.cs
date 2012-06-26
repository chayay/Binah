using System;

namespace Binah.Web.Api
{
	public class CommonSetup
	{
		public static void Setup()
		{
			WorkAroundNastyDotNetFrameworkBug();
		}

		private static void WorkAroundNastyDotNetFrameworkBug()
		{
			// Work around nasty .NET framework bug
			try
			{
				new Uri("http://fail/first/time?only=%2bplus");
			}
			catch (Exception)
			{
			}
		}
	}
}