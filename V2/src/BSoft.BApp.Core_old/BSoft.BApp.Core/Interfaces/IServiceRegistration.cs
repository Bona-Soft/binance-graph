// Copyright (c) BonaSoft, Inc. All rights reserved.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BSoft.BApp.Core.Interfaces
{
    public interface IServiceRegistration
    {
        int Order { get; }
        void RegisterServices(IServiceCollection serviceProvider, IConfiguration configuration);
    }
}
