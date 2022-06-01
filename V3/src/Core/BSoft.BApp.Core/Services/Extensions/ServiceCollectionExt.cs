// Copyright (c) BonaSoft, Inc. All rights reserved.

using BSoft.BApp.Core.Extensions;
using BSoft.BApp.Core.Services.Infraestructure;
using Microsoft.Extensions.DependencyInjection;

namespace BSoft.BApp.Core.Services.Extensions
{
    public static class ServiceCollectionExt
    {
        public static IServicesToRegister FindAllServiceToRegisterFrom<TImplementedParentInterface>(this IServiceCollection serviceCollection)
            where TImplementedParentInterface : class
        {
            return new ServicesToRegister(
                TypeExt.FindAllServiceToRegisterFrom<TImplementedParentInterface>(),
                serviceCollection);
        }
    }
}
