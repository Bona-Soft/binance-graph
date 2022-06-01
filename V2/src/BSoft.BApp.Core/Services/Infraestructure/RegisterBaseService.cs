// Copyright (c) BonaSoft, Inc. All rights reserved.

using BSoft.BApp.Core.Infraestructure;
using BSoft.BApp.Core.Infraestructure.Interfaces;
using BSoft.BApp.Core.Services.Extensions;
using BSoft.BApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BSoft.BApp.Core.Services.Infraestructure
{
    public class RegisterBaseService : IBaseServiceRegistration
    {
        public int Order => 99;

        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            RegisterBaseServices(services);
        }

        private void RegisterBaseServices(IServiceCollection services)
        {
            services
                .FindAllServiceToRegisterFrom<IBaseService>()
                .AddAsKeyedServices<IBaseService>();

            services.AddScoped<IBaseServiceProvider, BaseServiceProvider>();
        }
    }
}
