﻿using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.EntityConfigurations
{
    internal class OrganizationSyncEntityTypeConfiguration
        : IEntityTypeConfiguration<OrganizationSync>
    {
        public void Configure(EntityTypeBuilder<OrganizationSync> builder)
        {
            builder.ToTable("organizationsyncs", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("organizationsyncs_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder
                .Property<long>("_organizationSyncId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("EntitySyncId")
                .IsRequired();

            builder
                .Property<long>("_subscriberId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("SubscriberId")
                .IsRequired();

            builder
                .Property<bool>("_isSync")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IsSync")
                .IsRequired();
        }
    }
}