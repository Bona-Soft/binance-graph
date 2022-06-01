// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using BSoft.BinanceGraph.DataAccess.Infrastructure.Queries;
using BSoft.BinanceGraph.Entities;

namespace BSoft.BinanceGraph.DataAccess.Queries.Interfaces
{
    public interface IApiConfigurationQueryBuilder : IBaseQueryBuilder<ApiConfiguration, Guid, IApiConfigurationQueryBuilder>
    {
    }
}
