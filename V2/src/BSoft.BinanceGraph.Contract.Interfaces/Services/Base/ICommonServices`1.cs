// Copyright (c) BSoft, Inc. All rights reserved.

using AutoMapper;
using BSoft.DemoApp.Contract.Interfaces.Accesor;
using BSoft.DemoApp.DataAccess.Infrastructure.Accesor;
using Microsoft.Extensions.Logging;

namespace BSoft.DemoApp.Services.Interfaces
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
