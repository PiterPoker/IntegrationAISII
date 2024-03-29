using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate;
using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate.IncomingMailingTrackAggregate;
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
    internal class MailingTrackEntityTypeConfiguration
        : IEntityTypeConfiguration<MailingTrack>
    {
        public void Configure(EntityTypeBuilder<MailingTrack> builder)
        {
            builder.ToTable("mailingtracks", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("mailingtracks_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder
                .HasDiscriminator<Guid>("MailingTrackType")
                .HasValue<MailingTrack>(Guid.Parse("880e79a1-7cd3-4b87-9412-6094b1dc1644"))
                .HasValue<IncomingMailingTrack>(Guid.Parse("5d2eab5f-7ebc-4782-8994-6c9497a8ab0d"));

            builder
                .HasDiscriminator<Guid>("MailingTrackType")
                .HasValue<MailingTrack>(Guid.Parse("880e79a1-7cd3-4b87-9412-6094b1dc1644"))
                .HasValue<OutgoingMailingTrack>(Guid.Parse("4472ffb8-5660-4a03-9621-c94154de0866"));

            /*builder
                .Property<Guid>("_typeGuid")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Discriminator")
                .IsRequired();*/

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

            /*builder
                .Property<long?>("_acknowledgementId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AcknowledgementId")
                .IsRequired(false);

            builder
                .Property<long?>("_messageId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("MessageId")
                .IsRequired(false);*/
        }
    }
}
