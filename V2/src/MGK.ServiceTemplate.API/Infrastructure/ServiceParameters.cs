using MGK.ServiceBase.Configuration.SeedWork;
using BSoft.DemoApp.API.Constants;
using System;

namespace BSoft.DemoApp.API.Infrastructure
{
	public class ServiceParameters : IMicroServiceParameters
	{
		public ServiceParameters()
		{
			ApiStartup = typeof(Startup);
			ClientAlias = CoreConstants.ClientAlias;
			ContextPath = CoreConstants.ContextPath;
			SwaggerDocumentName = typeof(Startup).Assembly.GetName().Name;
		}

		public Type ApiStartup { get; }

		public string ClientAlias { get; }

		public string ContextPath { get; }

		public string SwaggerDocumentName { get; }
	}
}
