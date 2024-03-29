using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate.OutgoingMailingTrackAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.EntityConfigurations
{
    internal class OutgoingMailingTrackEntityTypeConfiguration
        : IEntityTypeConfiguration<OutgoingMailingTrack>
    {
        public void Configure(EntityTypeBuilder<OutgoingMailingTrack> builder)
        {
            /*builder.ToTable("mailingtracks", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("mailingtracks_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder
                .Property<Guid>("_typeGuid")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Discriminator")
                .IsRequired();

            builder
                .Property<DateTime>("_createDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CreateDate")
                .IsRequired();

            builder
                .Property<string>("_description")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Description")
                .IsRequired();

            builder
                .Property<bool>("_isUnread")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IsUnread")
                .IsRequired();

            builder
                .Property<int>("_statusId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("StatusId")
                .IsRequired();

            builder
                .Property<long?>("_acknowledgementId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AcknowledgementId")
                .IsRequired();

            builder
                .Property<long?>("_receiverId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ReceiverId")
                .IsRequired();

            builder
                .HasOne(u => u.Receiver)
                .WithOne()
                .HasForeignKey<OutgoingMailingTrack>("_receiverId")
                .IsRequired(false);

            builder
                .HasOne(u => u.Acknowledgement)
                .WithOne()
                .HasForeignKey<OutgoingMailingTrack>("AcknowledgementId")
                .IsRequired(false);*/
        }
    }
}
