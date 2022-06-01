// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using BSoft.BinanceGraph.DataAccess.Infrastructure.Configurations;
using BSoft.BinanceGraph.Entities;
using MGK.ServiceBase.DAL.Infrastructure.DataUnits;
using MGK.ServiceBase.DAL.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSoft.BinanceGraph.DataAccess.Configurations
{
    public class ApiConfigurationConfiguration : AuditableEntityConfiguration<ApiConfiguration, Guid>
    {
        public override void Configure(EntityTypeBuilder<ApiConfiguration> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.ApiKey).IsRequired();
            builder.Property(p => p.ApiProvider).IsRequired();
            builder.Property(p => p.SecretKey).IsRequired();
        }
    }
}
