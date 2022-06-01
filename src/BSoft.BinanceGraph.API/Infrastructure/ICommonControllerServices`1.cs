// Copyright (c) BonaSoft, Inc. All rights reserved.

using AutoMapper;
using Microsoft.Extensions.Logging;

namespace BSoft.BinanceGraph.API.Infrastructure
{
    public interface ICommonControllerServices<T>
    {
        public IMapper Mapper { get; }

        public ILogger<T> Logger { get; }
    }
}
