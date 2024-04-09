using IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate;
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
                .Property<Guid>("AckMessageGuid")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AckMessageGuid")
                .IsRequired();

            /*builder
                .Property<Guid>("_acknowledgementType")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Discriminator")
                .IsRequired();*/

            builder
                .Property<DateTime>("CreateDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CreateDate")
                .IsRequired();

            builder
                .Property<int>("ErrorCode")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ErrorCode")
                .IsRequired();

            builder
                .Property<string>("ErrorText")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("ErrorText")
                .IsRequired();

            builder
                .Property<bool>("IsLocked")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IsLocked")
                .IsRequired();

            builder
                .Property<Guid>("PackageId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("PackageId")
                .IsRequired();

            builder
                .Property<string>("Subject")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Subject")
                .IsRequired();

            builder
                .Property<int>("AckTypeId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AckTypeId")
                .IsRequired();

            builder
                .Property<int>("StatusId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("StatusId")
                .IsRequired();

            builder
                .Property<long>("MessageId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("MessageId")
                .IsRequired();
        }
    }
}
