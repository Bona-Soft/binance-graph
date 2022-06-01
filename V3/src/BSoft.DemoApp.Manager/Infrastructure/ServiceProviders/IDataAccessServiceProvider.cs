// Copyright (c) BonaSoft, Inc. All rights reserved.

using BSoft.BApp.Core.DataAccess.Interfaces;
using MGK.ServiceBase.Services.SeedWork;

namespace BSoft.DemoApp.Manager.Infrastructure.ServiceProviders
{
    public interface IDataAccessServiceProvider : IServiceProvider<string, IBaseDataAccessService>
    {
        TOutputService Get<TOutputService>()
            where TOutputService : class, IBaseDataAccessService;
    }
}
