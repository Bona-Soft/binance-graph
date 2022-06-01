// Copyright (c) BonaSoft, Inc. All rights reserved.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BSoft.BApp.Core.Infraestructure.Interfaces
{
    /// <summary>
    /// Every class that implement this interface it will be running RegisterServices when BaseServiceRegistration.RegisterAllServiceRegistrations is call on startup.
    /// </summary>
    public interface IBaseServiceRegistration
    {
        int Order { get; }
        void RegisterServices(IServiceCollection serviceProvider, IConfiguration configuration);
    }
}
