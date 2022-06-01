// Copyright (c) BonaSoft, Inc. All rights reserved.

using AutoMapper;
using BSoft.BApp.Services;
using MGK.ServiceBase.Services;
using Microsoft.Extensions.Logging;

namespace BSoft.BApp.Core.Services
{
    public class BaseInternalServices<T> : InternalServices<T>, IBaseInternalServices<T>
        where T : class, IBaseService
    {
        public BaseInternalServices(
            IMapper mapper,
            ILogger<T> logger)
            : base(mapper, logger)
        {
        }
    }
}
