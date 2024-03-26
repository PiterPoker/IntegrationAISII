using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.EntityConfigurations
{
    internal class TypeMaterialEntityTypeConfiguration
        : IEntityTypeConfiguration<TypeMaterial>
    {
        public void Configure(EntityTypeBuilder<TypeMaterial> builder)
        {
            builder.ToTable("typematerials", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(ct => ct.Id);

            builder.Property(ct => ct.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(ct => ct.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
