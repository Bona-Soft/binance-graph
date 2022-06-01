// Copyright (c) BonaSoft, Inc. All rights reserved.

using BSoft.BApp.Core.DataAccess.Interfaces;
using BSoft.BApp.Services;
using MGK.ServiceBase.Services.SeedWork;

namespace BSoft.BApp.Core.Infraestructure.Interfaces
{
    public interface IBaseServiceProvider : IServiceProvider<string, IBaseService>
    {
        TOutputService Get<TOutputService>()
            where TOutputService : class, IBaseService;
    }
}
