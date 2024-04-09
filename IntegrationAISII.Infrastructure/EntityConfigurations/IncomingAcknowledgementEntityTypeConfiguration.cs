using IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.IncomingAcknowledgementAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.EntityConfigurations
{
    internal class IncomingAcknowledgementEntityTypeConfiguration
        : IEntityTypeConfiguration<IncomingAcknowledgement>
    {
        public void Configure(EntityTypeBuilder<IncomingAcknowledgement> builder)
        {
            /*builder.ToTable("acknowledgements", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("acknowledgements_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder
                .Property<Guid>("_ackMessageGuid")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AckMessageGuid")
                .IsRequired();

            builder
                .Property<Guid>("_acknowledgementType")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Discriminator")
                .IsRequired();

            builder
                .Property<DateTime>("_createDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CreateDate")
                .IsRequired();

            builder
                .Property<int>("_errorCode")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ErrorCode")
                .IsRequired();

            builder
                .Property<string>("_errorText")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ErrorText")
                .IsRequired();

            builder
                .Property<bool>("_isLocked")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IsLocked")
                .IsRequired();

            builder
                .Property<Guid>("_packageId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("PackageId")
                .IsRequired();

            builder
                .Property<string>("_subject")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Subject")
                .IsRequired();

            builder
                .Property<int>("_ackTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AckTypeId")
                .IsRequired();

            builder
                .Property<int>("_statusId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("StatusId")
                .IsRequired();*/

            builder.HasMany(b => b.MailingTracks)
               .WithOne()
               .HasForeignKey("AcknowledgementId")
               .OnDelete(DeleteBehavior.Cascade);

            /*builder.HasOne(b => b.Message)
               .WithOne()
               .HasForeignKey("AcknowledgementId");*/

            /*builder.HasOne(p => p.AckType)
                .WithMany()
                .HasForeignKey("AckTypeId");

            builder.HasOne(p => p.Status)
                .WithMany()
                .HasForeignKey("StatusId");*/
            
            builder.HasOne(b => b.Message)
               .WithOne()
               .HasForeignKey<IncomingAcknowledgement>("AcknowledgementId")
               .IsRequired();

            var navigation = builder.Metadata.FindNavigation(nameof(IncomingAcknowledgement.MailingTracks));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
