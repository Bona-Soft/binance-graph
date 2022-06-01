using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MGK.Acceptance;
using MGK.ServiceBase.DAL.SeedWork;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BSoft.BinanceGraph.DataAccess.Infrastructure.Extensions
{
    internal static class EntityTypeBuilderExtensions
    {
        public static void SetupBaseEntity<TEntity, TKey>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : class, IDataUnit<TKey>
        {
            Ensure.Value.IsNotNull(builder, nameof(builder));

            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }

        //public static void SetupBaseEntity<TEntity>(this EntityTypeBuilder<TEntity> builder)
        //    where TEntity : IDataUnit
        //{
        //    Ensure.Value.IsNotNull(builder, nameof(builder));

        //    builder.Property(p => p.Id).ValueGeneratedOnAdd();
        //}
    }
}
