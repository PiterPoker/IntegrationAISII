using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.EntityConfigurations
{
    internal class SignatureEntityTypeConfiguration
        : IEntityTypeConfiguration<Signature>
    {
        public void Configure(EntityTypeBuilder<Signature> builder)
        {
            builder.ToTable("signatures", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("signatures_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder
                .Property<string>("_signer")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Signer")
                .IsRequired();

            builder
                .Property<DateTime>("_signTime")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("SignTime")
                .IsRequired();

            builder
                .Property<byte[]>("_value")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Value")
                .IsRequired();

            builder
                .Property<long>("_versionId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("VersionId")
                .IsRequired();
        }
    }
}
