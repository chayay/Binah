﻿using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Binah.Infrastructure.RavenDB;

namespace Binah.Web.Api
{
	public class WebApiApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			DocumentStoreHolder.Initialize();
			using (var session = DocumentStoreHolder.OpenSession())
			{
				new ImportData(session).Import();
				session.SaveChanges();
			}

			WebApiSetup.Setup(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalConfiguration.Configuration.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			CommonSetup.Setup();
		}
	}
}