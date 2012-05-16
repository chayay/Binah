using System;
using System.Text;
using Binah.Infrastructure.RavenDB;
using Binah.Migrations.Import;

namespace Binah.Migrations
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.InputEncoding = Encoding.UTF8;
			Console.OutputEncoding = Encoding.UTF8;

			DocumentStoreHolder.Initialize();

			new OpenSiddurOpenDocumentImporter().Import();
			//new CommandsRunner().LookForCommands();
		}
	}
}