using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Version = IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.Version;

namespace IntegrationAISII.Infrastructure.EntityConfigurations
{
    internal class VersionEntityTypeConfiguration
        : IEntityTypeConfiguration<Version>
    {
        public void Configure(EntityTypeBuilder<Version> builder)
        {
            builder.ToTable("versions", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("versions_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder
                .Property<string>("FileName")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("FileName")
                .IsRequired();

            builder
                .Property<string>("Noname")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Noname")
                .IsRequired();

            builder
                .Property<string>("Author")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Author")
                .IsRequired();

            builder
                .Property<long?>("FileTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("FileTypeId")
                .IsRequired();

            /*builder
                .Property<long?>("_documentId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("DocumentId")
                .IsRequired(false);*/

            builder
                .HasMany(b => b.Signatures)
                .WithOne()
                .HasForeignKey("VersionId")
                .OnDelete(DeleteBehavior.Cascade);

            var signatures = builder.Metadata.FindNavigation(nameof(Version.Signatures));

            signatures.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
