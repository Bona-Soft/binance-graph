// Copyright (c) BonaSoft, Inc. All rights reserved.

using System;
using BSoft.DemoApp.Entities;
using MGK.ServiceBase.DAL.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BSoft.DemoApp.DataAccess.Configurations.ProofOfConcept
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.SetupBaseEntity<Person, Guid>();

            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Surname).HasMaxLength(255).IsRequired();
        }
    }
}
