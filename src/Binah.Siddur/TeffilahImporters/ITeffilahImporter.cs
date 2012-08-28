using System;
using Binah.Core.Models;

namespace Binah.Siddur.TeffilahImporters
{
	public interface ITeffilahImporter
	{
		void Import(Action<Entity> store);
	}
}