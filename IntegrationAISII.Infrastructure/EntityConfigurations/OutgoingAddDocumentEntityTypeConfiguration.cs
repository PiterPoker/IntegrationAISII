using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate.OutgoingAddDocumentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.EntityConfigurations
{
    internal class OutgoingAddDocumentEntityTypeConfiguration
        : IEntityTypeConfiguration<OutgoingAddDocument>
    {
        public void Configure(EntityTypeBuilder<OutgoingAddDocument> builder)
        {
            builder.ToTable("adddocuments", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("adddocuments_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder
                .Property<Guid>("_addDocumentType")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Discriminator")
                .IsRequired();

            builder
                .Property<Guid>("_addDocumentGuid")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AddDocumentGuid")
                .IsRequired();

            builder
                .Property<int>("_addTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AddTypeId")
                .IsRequired();

            builder
                .Property<string>("_content")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Content")
                .IsRequired();

            builder
                .Property<long>("_outgoingMessageId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("MessageId")
                .IsRequired();

            builder
                .Property<long?>("_mainDocumentId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("MainDocumentId")
                .IsRequired();

            builder
                .HasOne(u => u.MainDocument)
                .WithOne()
                .HasForeignKey<OutgoingAddDocument>("_mainDocumentId")
                .IsRequired(false);

            builder
                .HasOne(u => u.Message)
                .WithOne()
                .HasForeignKey<OutgoingAddDocument>("_outgoingMessageId")
                .IsRequired();

            builder
                .HasMany(b => b.Versions)
                .WithOne()
                .HasForeignKey("VersionId")
                .OnDelete(DeleteBehavior.Cascade);

            var versions = builder.Metadata.FindNavigation(nameof(OutgoingAddDocument.Versions));

            versions.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}