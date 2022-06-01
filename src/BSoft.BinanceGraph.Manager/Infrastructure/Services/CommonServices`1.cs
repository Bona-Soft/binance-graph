// Copyright (c) Zenfolio, Inc. All rights reserved.

using System;
using Autofac.Features.Indexed;
using AutoMapper;
using BSoft.BinanceGraph.Contract.Interfaces.Accesor;
using BSoft.BinanceGraph.DataAccess.Infrastructure.UnitOfWork;
using BSoft.BinanceGraph.Manager.Interfaces;
using MGK.Acceptance;
using Microsoft.Extensions.Logging;

namespace BSoft.BinanceGraph.Manager.Services.Base
{
    public class CommonServices<T> : ICommonServices<T>
    {
        public CommonServices(
            IBinanceUoW unitOfWork,
            IQueryBuilders queryBuilders,
            IMapper mapper,
            ILogger<T> logger)
        {
            //Ensure.IsNotNull(unitOfWork, nameof(unitOfWork));
            //Ensure.Any.IsNotNull(queryBuilders, nameof(queryBuilders));
            //Ensure.Any.IsNotNull(mapper, nameof(mapper));
            //Ensure.Any.IsNotNull(busPublisher, nameof(busPublisher));
            //Ensure.Any.IsNotNull(logger, nameof(logger));

            QueryBuilders = queryBuilders;
            UnitOfWork = unitOfWork;
            Logger = logger;
            Mapper ??= mapper;
        }

        public IQueryBuilders QueryBuilders { get; }

        public IMapper Mapper { get; }

        public IBinanceUoW UnitOfWork { get; }

        public ILogger<T> Logger { get; }
    }
}
