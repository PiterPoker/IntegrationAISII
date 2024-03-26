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
    internal class DocumentTypeEntityTypeConfiguration
        : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ToTable("documenttypes", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("documenttypes_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder
                .Property<Guid>("_objid")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ObjId")
                .IsRequired();

            builder
                .Property<DateTime>("_createDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CreateDate")
                .IsRequired();

            builder
                .Property<Guid>("_aisiiId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AisiiId")
                .IsRequired();

            builder
                .Property<bool>("_isActual")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IsActual")
                .IsRequired();

            builder
                .Property<string>("_name")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Name")
                .IsRequired(false);

            builder.HasMany(b => b.DocumentTypeSyncs)
               .WithOne()
               .HasForeignKey("EntitySyncId")
               .OnDelete(DeleteBehavior.Cascade);

            var navigation = builder.Metadata.FindNavigation(nameof(DocumentType.DocumentTypeSyncs));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
