using System;
using System.Text;

namespace Binah.Migrations
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.InputEncoding = Encoding.UTF8;
			Console.OutputEncoding = Encoding.UTF8;

			new CommandsRunner().LookForCommands();
		}
	}
}