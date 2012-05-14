using System;
using System.Linq;
using Binah.Migrations.Import;

namespace Binah.Migrations
{
	public class CommandsRunner
	{
		public void LookForCommands()
		{
			var importers = GetType().Assembly.GetTypes()
				.Where(type => typeof(IImporter).IsAssignableFrom(type) && !type.IsAbstract)
				.ToArray();

			while (true)
			{
				Console.WriteLine("Binah Migration");
				Console.WriteLine("a. importers");
				for (var i = 0; i < importers.Length; i++)
				{
					var type = importers[i];
					Console.WriteLine("\t{0}: {1}", i + 1, type.Name);
				}
				Console.WriteLine();

				Console.WriteLine("Choose task to run, or one of the follwoing commands: q");
				var line = Console.ReadLine();
				if (line == "q")
					return;
				if (!string.IsNullOrWhiteSpace(line) && line.Length >= 2)
				{
					int id;
					if (int.TryParse(line.Remove(0, 1), out id))
					{
						var c = line[0];
						if (c == 'a' && (id >= 1 || id <= importers.Length))
						{
							var importer = (IImporter) Activator.CreateInstance(importers[id - 1]);
							importer.Import();
							continue;
						}
					}
				}

				Console.WriteLine("Cannot understand '{0}'", line);
				Console.WriteLine();
			}
		}
	}
}