using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.SelfHost;
using Binah.Core.Extensions;
using Binah.Web.Api.Routes;

namespace Binah.Web.Api
{
	public class Server
	{
		private readonly HttpSelfHostServer server;
		private readonly HttpSelfHostConfiguration configuration;

		public Server()
		{
			configuration = new HttpSelfHostConfiguration("http://localhost:9090");
			RegisterRoutes(configuration.Routes);
			server = new HttpSelfHostServer(configuration);
		}

		public void Start()
		{
			server.OpenAsync().Wait();
			Console.WriteLine("Server is Running.");
			while (true)
			{
				var line = Console.ReadLine();
				switch (line)
				{
					case "q":
						server.CloseAsync().Wait();
						server.Dispose();
						configuration.Dispose();
						return;
					default:
						Console.WriteLine("Don't know how to handle '{0}'. Available commands: q.", line);
						break;
				}
			}
		}

		private void RegisterRoutes(HttpRouteCollection routes)
		{
			GetType().Assembly.GetTypes()
				.Where(type => typeof(IRouteRegistry).IsAssignableFrom(type) && type.IsAbstract == false)
				.Select(type => ((IRouteRegistry)Activator.CreateInstance(type)))
				.OrderBy(registry => registry.Priority)
				.ForEach(registry => registry.RegisterRoutes(routes));
		}
	}
}