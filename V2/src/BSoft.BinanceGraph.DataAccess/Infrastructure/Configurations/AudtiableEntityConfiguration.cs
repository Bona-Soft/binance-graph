// Copyright (c) BonaSoft, Inc. All rights reserved.

using MGK.ServiceBase.DAL.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSoft.BinanceGraph.DataAccess.Infrastructure.Configurations
{
    public abstract class AuditableEntityConfiguration<TEntity, TKey> : BaseEntityConfiguration<TEntity, TKey>, IEntityTypeConfiguration<TEntity>
        where TEntity : class, IAuditableDataUnit<TKey>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            // builder.Property(p => p.DateCreated).HasDefaultValueSql("now() at time zone 'utc'");
            // builder.Property(p => p.DateModified).HasDefaultValueSql("now() at time zone 'utc'").ValueGeneratedOnUpdate();
        }
    }
}
