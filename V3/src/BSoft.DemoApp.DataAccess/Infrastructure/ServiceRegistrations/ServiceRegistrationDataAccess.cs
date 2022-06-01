// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using System.Collections.Generic;
using BSoft.BApp.Core.DataAccess.Interfaces;
using BSoft.BApp.Core.Infraestructure.Interfaces;
using BSoft.BApp.Core.Services.Extensions;
using BSoft.DemoApp.DataAccess.Contexts;
using BSoft.DemoApp.DataAccess.Infrastructure.Enums;
using BSoft.DemoApp.DataAccess.Infrastructure.Queries.ProofOfConcept;
using BSoft.DemoApp.DataAccess.Infrastructure.UnitOfWork;
using BSoft.DemoApp.DataAccess.Queries.ProofOfConcept;
using BSoft.DemoApp.DataAccess.UnitOfWork;
using MGK.ServiceBase.DAL.Infrastructure.Extensions;
using MGK.ServiceBase.Services.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BSoft.DemoApp.DataAccess.Infrastructure.Extensions
{
    public class ServiceRegistrationDataAccess : IBaseServiceRegistration
    {
        public int Order => 5;

        public void RegisterServices(IServiceCollection serviceProvider, IConfiguration configuration)
        {
            serviceProvider.AddDALServices(configuration);

            AddContexts(serviceProvider);
            AddDataAccessServices(serviceProvider);

            serviceProvider.RunDbMigrations();
        }

        private static void AddContexts(IServiceCollection services)
        {
            services.AddDbContext<Contexts.AppContext>(nameof(AvailableDatabase.ProofOfConcept));
        }

        private static void AddDataAccessServices(IServiceCollection services)
        {
            var queryConstructors = new Dictionary<string, Type>
            {
                // Query Constructors
                { nameof(IPersonQueryConstructor), typeof(PersonQueryConstructor) },
                // Units of Work
                { nameof(IProofOfConceptUoW), typeof(ProofOfConceptUoW) }
            };

            services
                .FindAllServiceToRegisterFrom<IBaseDataAccessService>()
                .AddAsKeyedServices<IBaseDataAccessService>();

            //services.AddScoped<IBaseServiceProvider, BaseServiceProvider>();

            //services.AddKeyedServices<IBaseDataAccessService, string>(queryConstructors);
        }
    }
}
