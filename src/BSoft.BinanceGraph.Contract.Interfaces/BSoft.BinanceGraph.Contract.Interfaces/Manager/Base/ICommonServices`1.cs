// Copyright (c) BSoft, Inc. All rights reserved.

using AutoMapper;
using BSoft.BinanceGraph.Contract.Interfaces.Accesor;
using BSoft.BinanceGraph.DataAccess.Infrastructure.UnitOfWork;
using Microsoft.Extensions.Logging;

namespace BSoft.BinanceGraph.Manager.Interfaces
{
    // TODO: should manager interfaces be moved to an other project or to contracts?
    public interface ICommonServices<T>
    {
        public IMapper Mapper { get; }

        public IBinanceUoW UnitOfWork { get; }

        public ILogger<T> Logger { get; }

        public IQueryBuilders QueryBuilders { get; }
    }
}
