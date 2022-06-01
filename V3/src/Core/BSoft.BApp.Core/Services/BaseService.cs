// Copyright (c) BonaSoft, Inc. All rights reserved.

using BSoft.BApp.Services;
using MGK.ServiceBase.Services;

namespace BSoft.DemoApp.Manager.Services.Base
{
    public abstract class BaseService<T> : ServiceBase<T>
        where T : class, IBaseService
    {
        protected BaseService(IBaseInternalServices<T> internalServices)
            : base(internalServices)
        {
        }
    }
}
