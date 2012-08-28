using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Binah.Core.Extensions
{
	public static class AssemblyExtensions
	{
		public static IEnumerable<T> GetAllImplementorsOf<T>(this Assembly assembly)
		{
			if (assembly == null) throw new ArgumentNullException("assembly");

			IEnumerable<Type> types;
			try
			{
				types = assembly.GetTypes();
			}
			catch (ReflectionTypeLoadException e)
			{
				types = e.Types.Where(t => t != null);
			}

			return types.Where(type => typeof (T).IsAssignableFrom(type) && !type.IsAbstract)
				.Select(x => (T) Activator.CreateInstance(x));
		}
	}
}