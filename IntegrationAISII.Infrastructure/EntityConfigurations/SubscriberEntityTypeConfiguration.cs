using IntegrationAISII.Domain.AggregatesModel.SubscriberAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.EntityConfigurations
{
    internal class SubscriberEntityTypeConfiguration
        : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.ToTable("subscribers", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("subscribers_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder
                .Property<Guid>("_subscriberGuid")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("SubscriberGuid")
                .IsRequired();

            builder
                .Property<long>("_organizationId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Organization")
                .IsRequired();

            builder
                .Property<string>("_login")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Login")
                .IsRequired();

            builder
                .Property<string>("_email")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Email")
                .IsRequired();

            builder
                .Property<string>("_password")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Password")
                .IsRequired();

            builder
                .HasOne(b => b.Organization)
                .WithOne()
                .HasForeignKey("Organization");
        }
    }
}
