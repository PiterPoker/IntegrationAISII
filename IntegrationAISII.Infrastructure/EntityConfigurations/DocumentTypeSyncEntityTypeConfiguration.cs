using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.DocumentTypeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.EntityConfigurations
{
    internal class DocumentTypeSyncEntityTypeConfiguration
        : IEntityTypeConfiguration<DocumentTypeSync>
    {
        public void Configure(EntityTypeBuilder<DocumentTypeSync> builder)
        {
            builder.ToTable("documenttypesyncs", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("documenttypesyncs_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder
                .Property<long>("_documentTypeId")
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
