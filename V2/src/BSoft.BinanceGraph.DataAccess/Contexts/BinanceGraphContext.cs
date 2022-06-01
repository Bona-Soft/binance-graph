// Copyright (c) BonaSoft, Inc. All rights reserved.

using BSoft.BinanceGraph.DataAccess.Infrastructure.Configurations;
using BSoft.BinanceGraph.DataAccess.Infrastructure.Enums;
using BSoft.BinanceGraph.Entities;
using MGK.ServiceBase.DAL;
using MGK.ServiceBase.DAL.Infrastructure.Extensions;
using MGK.ServiceBase.DAL.Infrastructure.Factories;
using Microsoft.EntityFrameworkCore;

namespace BSoft.BinanceGraph.DataAccess.Contexts
{
    public class BinanceGraphContext : CustomDbContext
    {
        public BinanceGraphContext(DbContextOptions<BinanceGraphContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApiConfiguration> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConventions()
                .ApplyConfigurationsFromAssembly(GetType().Assembly, typeof(IBinanceGraphConfiguration));
        }
    }
}
