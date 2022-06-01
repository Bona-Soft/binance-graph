// Copyright (c) BonaSoft, Inc. All rights reserved.

using AutoMapper;
using BSoft.BApp.Core.Controller.Interfaces;
using BSoft.BApp.Core.Infraestructure.Interfaces;
using MGK.Acceptance;
using Microsoft.Extensions.Logging;

namespace BSoft.BApp.Core.Controller
{
    public class BaseCommonControllerServices<T> : IBaseCommonControllerServices<T>
    {
        public BaseCommonControllerServices(
            IMapper mapper,
            ILogger<T> logger,
            IBaseServiceProvider managerServiceProvider)
        {
            Ensure.Value.IsNotNull(mapper, nameof(mapper));
            Ensure.Value.IsNotNull(logger, nameof(logger));
            Logger = logger;
            Mapper ??= mapper;
            ManagerServiceProvider ??= managerServiceProvider;
        }

        public IMapper Mapper { get; }

        public ILogger<T> Logger { get; }

        public IBaseServiceProvider ManagerServiceProvider { get; }
    }
}
