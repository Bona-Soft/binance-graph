// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using BSoft.BApp.Core.Infraestructure.Interfaces;
using BSoft.BApp.Services;
using MGK.ServiceBase.Services;

namespace BSoft.BApp.Core.Infraestructure
{
    public class BaseServiceProvider : ServiceProvider<string, IBaseService>, IBaseServiceProvider
    {
        public BaseServiceProvider(Func<string, IBaseService> managerServices)
            : base(managerServices)
        {
        }

        public TOutputService Get<TOutputService>()
            where TOutputService : class, IBaseService
        {
            var key = typeof(TOutputService).Name;
            return Get<TOutputService>(key);
        }
    }
}
