using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.IncomingDocumentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.EntityConfigurations
{
    internal class IncomingDocumentEntityTypeConfiguration
        : IEntityTypeConfiguration<IncomingDocument>
    {
        public void Configure(EntityTypeBuilder<IncomingDocument> builder)
        {
            /*builder.ToTable("documents", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("documents_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder
                .Property<string>("_idNumber")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IdNumber")
                .IsRequired();

            builder
                .Property<Guid>("_documentKind")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Discriminator")
                .IsRequired();

            builder
                .Property<long>("_documentTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("DocumentTypeId")
                .IsRequired();

            builder
                .Property<bool>("_isConfident")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IsConfident")
                .IsRequired();

            builder
                .Property<string>("_regNumber")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("RegNumber")
                .IsRequired();

            builder
                .Property<int>("_pages")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Pages")
                .IsRequired();

            builder
                .Property<DateTime>("_regDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("RegDate")
                .IsRequired();

            builder
                .Property<Guid>("_documentGuid")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("DocumentGuid")
                .IsRequired();

            builder
                .Property<string>("_title")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Title")
                .IsRequired();

            builder
                .Property<long?>("_parantMessageId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ParentMessageId")
                .IsRequired(false);

            builder
                .Property<long?>("_mainMessageId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("MainMessageId")
                .IsRequired(false);

            builder
                .Property<long>("_messageId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("MessageId")
                .IsRequired();*/

            builder
                .HasOne(u => u.ParentMessage)
                .WithOne()
                .HasForeignKey<IncomingDocument>("ParentMessageId")
                .IsRequired(false);

            builder
                .HasOne(u => u.MainMessage)
                .WithOne()
                .HasForeignKey<IncomingDocument>("MainMessageId")
                .IsRequired(false);

            builder
                .HasOne(u => u.Message)
                .WithOne()
                .HasForeignKey<IncomingDocument>("MessageId")
                .IsRequired();

            /*builder
                .HasMany(b => b.Versions)
                .WithOne()
                .HasForeignKey("DocumentId")
                .OnDelete(DeleteBehavior.Cascade);

            var versions = builder.Metadata.FindNavigation(nameof(IncomingDocument.Versions));

            versions.SetPropertyAccessMode(PropertyAccessMode.Field);*/

        }
    }
}
