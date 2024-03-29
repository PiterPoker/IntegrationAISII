﻿using IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate;
using IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.IncomingAcknowledgementAggregate;
using IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.OutgoingAcknowledgementAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.EntityConfigurations
{
    internal class AcknowledgementEntityTypeConfiguration
        : IEntityTypeConfiguration<Acknowledgement>
    {
        public void Configure(EntityTypeBuilder<Acknowledgement> builder)
        {
            builder.ToTable("acknowledgements", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("acknowledgements_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder
                .HasDiscriminator<Guid>("MessageType")
                .HasValue<Acknowledgement>(Guid.Parse("a23d0fe2-f362-4f9b-b7a4-bc01bafd7940"))
                .HasValue<IncomingAcknowledgement>(Guid.Parse("597cf4f2-99b6-427a-b3f9-4b3f6eed3b6a"));

            builder
                .HasDiscriminator<Guid>("MessageType")
                .HasValue<Acknowledgement>(Guid.Parse("a23d0fe2-f362-4f9b-b7a4-bc01bafd7940"))
                .HasValue<OutgoingAcknowledgement>(Guid.Parse("d534e33d-ff98-4960-917a-4b8731eea3fd"));

            builder
                .Property<Guid>("_ackMessageGuid")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AckMessageGuid")
                .IsRequired();

            /*builder
                .Property<Guid>("_acknowledgementType")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Discriminator")
                .IsRequired();*/

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
                .IsRequired();

            builder
                .Property<long>("_message")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Message")
                .IsRequired();

            builder
                .Property<long?>("_responseToId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ResponseTo")
                .IsRequired(false);
        }
    }
}
