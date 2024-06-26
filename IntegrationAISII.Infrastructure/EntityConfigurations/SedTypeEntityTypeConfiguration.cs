﻿using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.SedTypeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.EntityConfigurations
{
    internal class SedTypeEntityTypeConfiguration
        : IEntityTypeConfiguration<SedType>
    {
        public void Configure(EntityTypeBuilder<SedType> builder)
        {
            builder.ToTable("sedtypes", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("sedtypes_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder
                .Property<Guid>("ObjId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ObjId")
                .IsRequired();

            builder
                .Property<DateTime>("CreateDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CreateDate")
                .IsRequired();

            builder
                .Property<Guid>("AisiiId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AisiiId")
                .IsRequired();

            builder
                .Property<bool>("IsActual")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IsActual")
                .IsRequired();

            builder
                .Property<string>("Name")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Name")
                .IsRequired(false);

            builder
                .Property<string>("Description")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Description")
                .IsRequired(false);

            builder
                .Property<string>("Version")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Version")
                .IsRequired(false);

            builder.HasMany(b => b.SedTypeSyncs)
               .WithOne()
               .HasForeignKey("EntitySyncId");

            var navigation = builder.Metadata.FindNavigation(nameof(SedType.SedTypeSyncs));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
