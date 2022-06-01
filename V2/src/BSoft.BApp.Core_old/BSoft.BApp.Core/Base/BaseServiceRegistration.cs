// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using BSoft.BApp.Core.Extensions;
using BSoft.BApp.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BSoft.BApp.Core.Base
{
    public abstract class BaseServiceRegistration
    {
        public static void RegisterAllServicers(IServiceCollection serviceProvider, IConfiguration configuration)
        {
            var serviceRegistrationsTypes = TypeExt.FindAllDerivedTypes<IServiceRegistration>();

            var serviceRegistrationInstances = new List<IServiceRegistration>();
            foreach (var serviceRegistrationType in serviceRegistrationsTypes)
            {
                var obj = (IServiceRegistration)Activator.CreateInstance(serviceRegistrationType);
                serviceRegistrationInstances.Add(obj);
            }

            foreach(var serviceRegistrationInstance in serviceRegistrationInstances.OrderBy(x => x.Order))
            {
                serviceRegistrationInstance.RegisterServices(serviceProvider, configuration);
            }
        }
    }
}
