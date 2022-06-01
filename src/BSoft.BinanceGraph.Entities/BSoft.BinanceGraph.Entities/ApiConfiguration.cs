// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using BSoft.BApp.Core.Interfaces;
using BSoft.BinanceGraph.Entities.Enums;
using MGK.ServiceBase.DAL.Infrastructure.DataUnits;

namespace BSoft.BinanceGraph.Entities
{
    public class ApiConfiguration : AuditableDataUnit<Guid>, IMappeable
    {
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
        public ApiProvider ApiProvider { get; set; }
    }
}
