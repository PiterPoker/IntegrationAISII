﻿using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.FileTypeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.EntityConfigurations
{
    internal class FileTypeEntityTypeConfiguration
        : IEntityTypeConfiguration<FileType>
    {
        public void Configure(EntityTypeBuilder<FileType> builder)
        {
            builder.ToTable("filetypes", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("filetypes_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

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
                .Property<string>("Extension")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Extension")
                .IsRequired(false);

            builder.HasMany(b => b.FileTypeSyncs)
               .WithOne()
               .HasForeignKey("EntitySyncId")
               .OnDelete(DeleteBehavior.Cascade);

            var navigation = builder.Metadata.FindNavigation(nameof(FileType.FileTypeSyncs));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
