// Copyright (c) BonaSoft, Inc. All rights reserved.

using BSoft.DemoApp.DataAccess.Infrastructure.Configurations;
using BSoft.DemoApp.DataAccess.Infrastructure.Enums;
using BSoft.DemoApp.Entities;
using MGK.ServiceBase.DAL;
using MGK.ServiceBase.DAL.Infrastructure.Extensions;
using MGK.ServiceBase.DAL.Infrastructure.Factories;
using Microsoft.EntityFrameworkCore;

namespace BSoft.DemoApp.DataAccess.Contexts
{
    public class AppContext : CustomDbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConventions()
                .ApplyConfigurationsFromAssembly(GetType().Assembly, typeof(IBaseConfiguration));
        }
    }

    public class ProofOfConceptContextDesignFactory : CustomDbContextDesignFactory<AppContext>
    {
        protected override string AppSettingsFile => "appsettings.local.json";

        protected override string DbName => nameof(AvailableDatabase.ProofOfConcept);
    }
}
