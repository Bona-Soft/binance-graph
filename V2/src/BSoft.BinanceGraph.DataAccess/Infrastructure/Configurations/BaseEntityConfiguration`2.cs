using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGK.ServiceBase.DAL.Infrastructure.Extensions;
using MGK.ServiceBase.DAL.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BSoft.BinanceGraph.DataAccess.Infrastructure.Extensions;

namespace BSoft.BinanceGraph.DataAccess.Infrastructure.Configurations
{
    public abstract class BaseEntityConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IDataUnit<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.SetupBaseEntity<TEntity, TKey>();

            ConfigureIndexes(builder);

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired();
        }

        protected virtual void ConfigureIndexes(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .HasIndex(e => new
                {
                    e.Id
                })
                .IsUnique();
        }
    }
}
