// Copyright (c) BonaSoft, Inc. All rights reserved.

using AutoMapper;
using BSoft.BinanceGraph.Contract.Interfaces.Accesor;
using BSoft.BinanceGraph.DataAccess.Infrastructure.UnitOfWork;
using BSoft.BinanceGraph.Manager.Interfaces;
using MGK.ServiceBase.DAL.SeedWork;
using Microsoft.Extensions.Logging;

namespace BSoft.BinanceGraph.Manager.Services.Base
{
    public class ServiceBase<T>
    {
        private readonly IQueryBuilders _queryBuilders;

        public ServiceBase(
            ICommonServices<T> commonServices)
        {
            _queryBuilders = commonServices.QueryBuilders;
            UnitOfWork = commonServices.UnitOfWork;
            Logger = commonServices.Logger;
            Mapper ??= commonServices.Mapper;
        }

        protected static IMapper Mapper { get; private set; }

        protected IBinanceUoW UnitOfWork { get; }

        protected ILogger<T> Logger { get; }

        protected TQueryBuilder QB<TQueryBuilder>()
            where TQueryBuilder : class, IQueryBuilder
        {
            return _queryBuilders.Resolve<TQueryBuilder>();
        }
    }
}
