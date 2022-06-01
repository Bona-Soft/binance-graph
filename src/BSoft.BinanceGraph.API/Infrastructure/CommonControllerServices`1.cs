// Copyright (c) Zenfolio, Inc. All rights reserved.

using System;
using Autofac.Features.Indexed;
using AutoMapper;
using BSoft.BinanceGraph.API.Infrastructure;
using BSoft.BinanceGraph.Contract.Interfaces.Accesor;
using BSoft.BinanceGraph.DataAccess.Infrastructure.UnitOfWork;
using BSoft.BinanceGraph.Manager.Interfaces;
using MGK.Acceptance;
using Microsoft.Extensions.Logging;

namespace BSoft.BinanceGraph.Manager.Services.Base
{
    public class CommonControllerServices<T> : ICommonControllerServices<T>
    {
        public CommonControllerServices(
            IMapper mapper,
            ILogger<T> logger)
        {
            Ensure.Value.IsNotNull(mapper, nameof(mapper));
            Ensure.Value.IsNotNull(logger, nameof(logger));

            Logger = logger;
            Mapper ??= mapper;
        }

        public IMapper Mapper { get; }

        public ILogger<T> Logger { get; }
    }
}
