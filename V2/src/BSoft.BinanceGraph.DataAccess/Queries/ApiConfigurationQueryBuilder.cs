// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using AutoMapper;
using BSoft.BinanceGraph.DataAccess.Contexts;
using BSoft.BinanceGraph.DataAccess.Infrastructure.Queries.ProofOfConcept;
using BSoft.BinanceGraph.DataAccess.Queries.Interfaces;
using BSoft.BinanceGraph.Entities;

namespace BSoft.BinanceGraph.DataAccess.Queries.ProofOfConcept
{
    public class ApiConfigurationQueryBuilder : BaseQueryBuilder<ApiConfiguration, Guid, IApiConfigurationQueryBuilder>, IApiConfigurationQueryBuilder
    {
        public ApiConfigurationQueryBuilder(BinanceGraphContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
