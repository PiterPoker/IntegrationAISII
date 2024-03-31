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
                .Property<Guid>("ObjId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ObjId")
                .IsRequired();

            builder
                .Property<DateTime>("CreateDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CreateDate")
                .IsRequired();

            builder
                .Property<Guid>("AisiiId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AisiiId")
                .IsRequired();

            builder
                .Property<bool>("IsActual")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IsActual")
                .IsRequired();

            builder
                .Property<string>("Name")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Name")
                .IsRequired(false);

            builder
                .Property<string>("SmdoCode")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("SmdoCode")
                .IsRequired();

            builder
                .Property<string>("Unp")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Unp")
                .IsRequired();

            builder
                .Property<string>("Soato")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Soato")
                .IsRequired();

            builder
                .Property<string>("Email")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Email")
                .IsRequired();

            builder
                .Property<string>("ShortName")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ShortName")
                .IsRequired();

            builder
                .Property<string>("Street")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Street")
                .IsRequired();

            builder
                .Property<string>("Corpus")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Corpus")
                .IsRequired();

            builder
                .Property<string>("AbonentBox")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AbonentBox")
                .IsRequired();

            builder
                .Property<string>("Phone")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Phone")
                .IsRequired();

            builder
                .Property<string>("Fax")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Fax")
                .IsRequired();

            builder
                .Property<string>("Home")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Home")
                .IsRequired();

            builder
                .Property<string>("PostIndex")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("PostIndex")
                .IsRequired();

            builder.HasMany(b => b.OrganizationSyncs)
               .WithOne()
               .HasForeignKey("EntitySyncId")
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.EdmsType)
               .WithOne()
               .HasForeignKey<Organization>("EdmsTypeId");

            var navigation = builder.Metadata.FindNavigation(nameof(Organization.OrganizationSyncs));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
