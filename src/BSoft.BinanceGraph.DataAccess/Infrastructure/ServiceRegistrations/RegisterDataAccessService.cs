// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using BSoft.BApp.Core.Extensions;
using BSoft.BinanceGraph.DataAccess.Contexts;
using BSoft.BinanceGraph.DataAccess.Infrastructure.Enums;
using BSoft.BinanceGraph.DataAccess.Infrastructure.Extensions;
using MGK.ServiceBase.DAL.Infrastructure.Extensions;
using MGK.ServiceBase.DAL.SeedWork;
using MGK.ServiceBase.SeedWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static BSoft.BinanceGraph.DataAccess.Infraestructure.Queries.QueryBuilders;

namespace BSoft.BinanceGraph.DataAccess.Infrastructure.ServiceRegistrations
{
    public class RegisterDataAccessService : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            RegisterBaseServices(services);

            services.RunDbMigrations();
        }

        private void RegisterBaseServices(IServiceCollection services)
        {
            services.AddDbContext<BinanceGraphContext>(nameof(AvailableDatabase.BinanceGraph));

            //TODO: Automatizar Interface e Implementacion.
            //services.AddScoped<IBinanceUoW, BinanceUoW>();
            IEnumerable<Type> unitOfWorks = TypeExt.FindAllDerivedTypes<IUnitOfWork>();
            foreach (var uow in unitOfWorks)
            {
                services.AddScoped(uow);
            }

            IEnumerable<Type> queryBuilders = TypeExt.FindAllDerivedTypes<IQueryBuilder>();
            //services.AddScoped(typeof(QueryProvider<>), provider => key =>
            //{
            //    if (!string.IsNullOrEmpty(key))
            //    {
            //        Type toResolveType = queryBuilders.Where(x => x.Name == key).Single();

            //        return (IQueryBuilder)provider.GetRequiredService(toResolveType);
            //    }

            //    throw new KeyNotFoundException();
            //});

            services.AddScoped<QueryProviderFactory>(provider => (string key) =>
            {
                if (!string.IsNullOrEmpty(key))
                {
                    Type toResolveType = queryBuilders.Where(x => x.Name == key).Single();

                    return (IQueryBuilder)provider.GetRequiredService(toResolveType);
                }

                throw new KeyNotFoundException();
            });
        }
    }
}
