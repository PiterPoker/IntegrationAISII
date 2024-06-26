﻿using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.IncomingDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.OutgoingDocumentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.EntityConfigurations
{
    internal class DocumentEntityTypeConfiguration
        : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable("documents", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("documents_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder
                .HasDiscriminator<Guid>("DocumentKind")
                .HasValue<Document>(Guid.Parse("c9b84fe2-f994-42b5-9e61-e05f5858ba58"))
                .HasValue<IncomingDocument>(Guid.Parse("9dc4f0a7-4983-491a-9fe7-04abb0699692"));

            builder
                .HasDiscriminator<Guid>("DocumentKind")
                .HasValue<Document>(Guid.Parse("c9b84fe2-f994-42b5-9e61-e05f5858ba58"))
                .HasValue<OutgoingDocument>(Guid.Parse("8e6389d8-78da-489d-865e-b4b9ecc4dda0"));

            builder
                .Property<string>("IdNumber")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IdNumber")
                .IsRequired();

            /*builder
                .Property<Guid>("_documentKind")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Discriminator")
                .IsRequired();*/

            builder
                .Property<long>("DocumentTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("DocumentTypeId")
                .IsRequired();

            builder
                .Property<bool>("IsConfident")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IsConfident")
                .IsRequired();

            builder
                .Property<string>("RegNumber")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("RegNumber")
                .IsRequired();

            builder
                .Property<int>("Pages")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Pages")
                .IsRequired();

            builder
                .Property<DateTime>("RegDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("RegDate")
                .IsRequired();

            builder
                .Property<Guid>("DocumentGuid")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("DocumentGuid")
                .IsRequired();

            builder
                .Property<string>("Title")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Title")
                .IsRequired();

            builder
                .Property<long?>("ParentMessageId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ParentMessageId")
                .IsRequired(false);

            builder
                .Property<long?>("MainMessageId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("MainMessageId")
                .IsRequired(false);

            builder
                .Property<long>("MessageId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("MessageId")
                .IsRequired();

            builder
                .HasMany(b => b.Versions)
                .WithOne()
                .HasForeignKey("DocumentId")
                .OnDelete(DeleteBehavior.Cascade);

            var versions = builder.Metadata.FindNavigation(nameof(Document.Versions));

            versions.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
