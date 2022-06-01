// Copyright (c) BonaSoft, Inc. All rights reserved.

using BSoft.BApp.Core.Infraestructure.Interfaces;
using BSoft.BApp.Core.Services;
using BSoft.BApp.Services;
using BSoft.DemoApp.Manager.Infrastructure.ServiceProviders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BSoft.DemoApp.Manager.Infrastructure.Extensions
{
    public class ServiceRegistrationManager : IBaseServiceRegistration
    {
        public int Order => 4;

        public void RegisterServices(IServiceCollection serviceProvider, IConfiguration configuration)
        {
            serviceProvider.AddScoped<IDataAccessServiceProvider, DataAccessServiceProvider>();
            serviceProvider.AddScoped(typeof(IBaseInternalServices<>), typeof(BaseInternalServices<>));
        }
    }
}
