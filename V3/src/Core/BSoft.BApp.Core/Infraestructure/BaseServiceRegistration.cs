// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using BSoft.BApp.Core.Controller;
using BSoft.BApp.Core.Controller.Interfaces;
using BSoft.BApp.Core.Extensions;
using BSoft.BApp.Core.Infraestructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BSoft.BApp.Core.Infraestructure
{
    public static class BaseServiceRegistration
    {
        /// <summary>
        /// Run all implemented clases for interface IBaseServiceRegistration.
        /// </summary>
        /// <param name="serviceProvider">The Microsoft.Extensions.DependencyInjection interface with the service collection for inject dependencies.</param>
        /// <param name="configuration">The Microsoft.Extensions.Configuration interface for inject dependencies</param>
        /// <param name="partialNamespace">Limit the scoped of assemblies search that contains this argument on his assembly name. Normally use your solution name to avoid trying register framework dll and other dependencies. This will improve the first run. Null or empty to search all.</param>
        public static void RegisterAllServiceRegistrations(this IServiceCollection serviceProvider, IConfiguration configuration, string partialNamespace = null)
        {
            var serviceRegistrationsTypes = TypeExt.FindAllDerivedTypes<IBaseServiceRegistration>(partialNamespace);

            var serviceRegistrationInstances = new List<IBaseServiceRegistration>();
            foreach (var serviceRegistrationType in serviceRegistrationsTypes)
            {
                var obj = (IBaseServiceRegistration)Activator.CreateInstance(serviceRegistrationType);
                serviceRegistrationInstances.Add(obj);
            }

            foreach (var serviceRegistrationInstance in serviceRegistrationInstances.OrderBy(x => x.Order))
            {
                serviceRegistrationInstance.RegisterServices(serviceProvider, configuration);
            }
        }

        public static void RegisterBaseCommonControllerService(this IServiceCollection serviceProvider, IConfiguration configuration)
        {
            serviceProvider.AddScoped(typeof(IBaseCommonControllerServices<>), typeof(BaseCommonControllerServices<>));
        }
    }
}
