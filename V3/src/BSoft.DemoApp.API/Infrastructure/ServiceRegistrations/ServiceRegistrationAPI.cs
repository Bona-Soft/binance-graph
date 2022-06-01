// Copyright (c) BonaSoft, Inc. All rights reserved.

using BSoft.BApp.Core.Infraestructure.Interfaces;
using MGK.ServiceBase.Configuration.SeedWork;
using MGK.ServiceBase.CQRS.Infrastructure.Extensions;
using MGK.ServiceBase.Infrastructure.Extensions;
using MGK.ServiceBase.Services.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BSoft.DemoApp.API.Infrastructure.Extensions
{
    public class ServiceRegistrationAPI : IBaseServiceRegistration
    {
        public int Order => 1;

        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMicroServiceParameters, ServiceParameters>();
            services.AddCqrsServices(configuration);
            services.AddApiServices(configuration);
            services.AddServicesInAssembly<Startup>(configuration);
        }
    }
}
