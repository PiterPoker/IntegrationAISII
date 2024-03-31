using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate.IncomingAddDocumentAggregate;
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
    internal class AddDocumentEntityTypeConfiguration
        : IEntityTypeConfiguration<AddDocument>
    {
        public void Configure(EntityTypeBuilder<AddDocument> builder)
        {
            builder.ToTable("adddocuments", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("adddocuments_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder
                .HasDiscriminator<Guid>("AddDocumentType")
                .HasValue<AddDocument>(Guid.Parse("0aa82b37-a993-4efd-bdc4-63ff55df850f"))
                .HasValue<IncomingAddDocument>(Guid.Parse("cae8ef83-8c91-46b1-a3c0-75a5fecaf624"));

            builder
                .HasDiscriminator<Guid>("AddDocumentType")
                .HasValue<AddDocument>(Guid.Parse("0aa82b37-a993-4efd-bdc4-63ff55df850f"))
                .HasValue<OutgoingAddDocument>(Guid.Parse("3d4cba68-ba9e-4b4e-ad61-487d64339e95"));

            /*builder
                .Property<Guid>("_addDocumentType")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Discriminator")
                .IsRequired();*/

            builder
                .Property<Guid>("AddDocumentGuid")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AddDocumentGuid")
                .IsRequired();

            builder
                .Property<int>("AddTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AddTypeId")
                .IsRequired();

            builder
                .Property<string>("Content")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Content")
                .IsRequired();

            builder
                .Property<long>("MessageId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("MessageId")
                .IsRequired();

            builder
                .Property<long?>("MainDocumentId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("MainDocumentId")
                .IsRequired(false);

            /*builder
                .HasMany(b => b.Versions)
                .WithOne()
                .HasForeignKey("VersionId")
                .OnDelete(DeleteBehavior.Cascade);*/
        }
    }
}
