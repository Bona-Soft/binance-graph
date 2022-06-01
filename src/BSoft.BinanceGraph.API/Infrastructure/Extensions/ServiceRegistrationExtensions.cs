// Copyright (c) BonaSoft, Inc. All rights reserved.

using BSoft.BApp.Core.Interfaces;
using MGK.ServiceBase.Configuration.SeedWork;
using MGK.ServiceBase.Infrastructure.Extensions;
using MGK.ServiceBase.SeedWork;
using MGK.ServiceBase.Services.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BSoft.BinanceGraph.API.Infrastructure.Extensions
{
    public class ServiceRegistrationExtensions : IServiceRegistration
    {
        public int Order => 2;

        //public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddSingleton<IServiceParameters, ServiceParameters>();
        //    services.AddBaseServices(configuration);
        //    services.AddManagerServices(configuration);
        //    services.AddServicesInAssembly<Startup>(configuration);
        //}

        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMicroServiceParameters, ServiceParameters>();
            services.AddServicesInAssembly<Startup>(configuration);
        }
    }
}
