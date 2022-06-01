// Copyright (c) BonaSoft, Inc. All rights reserved.

using BSoft.BApp.Core.DataAccess.Interfaces;
using MGK.ServiceBase.Services;

namespace BSoft.DemoApp.Manager.Infrastructure.ServiceProviders
{
    public sealed class DataAccessServiceProvider : ServiceProvider<string, IBaseDataAccessService>, IDataAccessServiceProvider
    {
        public DataAccessServiceProvider(System.Func<string, IBaseDataAccessService> dataAccessServices)
            : base(dataAccessServices)
        {
        }

        public TOutputService Get<TOutputService>()
            where TOutputService : class, IBaseDataAccessService
        {
            var key = typeof(TOutputService).Name;
            return Get<TOutputService>(key);
        }
    }
}
