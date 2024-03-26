using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.EntityConfigurations
{
    internal class OrganizationEntityTypeConfiguration
        : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("organizations", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("organizations_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

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

            builder
                .Property<string>("_smdoCode")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("SmdoCode")
                .IsRequired();

            builder
                .Property<string>("_unp")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Unp")
                .IsRequired();

            builder
                .Property<string>("_soato")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Soato")
                .IsRequired();

            builder
                .Property<string>("_mail")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Email")
                .IsRequired();

            builder
                .Property<string>("_shortName")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ShortName")
                .IsRequired();

            builder
                .Property<string>("_street")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Street")
                .IsRequired();

            builder
                .Property<string>("_corpus")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Corpus")
                .IsRequired();

            builder
                .Property<string>("_abonentBox")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AbonentBox")
                .IsRequired();

            builder
                .Property<string>("_phone")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Phone")
                .IsRequired();

            builder
                .Property<string>("_fax")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Fax")
                .IsRequired();

            builder
                .Property<string>("_home")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Home")
                .IsRequired();

            builder
                .Property<string>("_postIndex")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("PostIndex")
                .IsRequired();

            builder.HasMany(b => b.OrganizationSyncs)
               .WithOne()
               .HasForeignKey("EntitySyncId")
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.EdmsType)
               .WithOne()
               .HasForeignKey("_edmsTypeId")
               .OnDelete(DeleteBehavior.Cascade);

            var navigation = builder.Metadata.FindNavigation(nameof(Organization.OrganizationSyncs));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
