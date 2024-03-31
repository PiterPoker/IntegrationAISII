using IntegrationAISII.Domain.AggregatesModel.MessageAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.IncomingMessageAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.OutgoingMessageAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.EntityConfigurations
{
    internal class MessageEntityTypeConfiguration
        : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("messages", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("messages_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder
                .HasDiscriminator<Guid>("MessageType")
                .HasValue<Message>(Guid.Parse("939cf108-1886-402d-8dae-130f21d36378"))
                .HasValue<IncomingMessage>(Guid.Parse("34c9fc63-fed1-42c7-9058-fba802002613"));

            builder
                .HasDiscriminator<Guid>("MessageType")
                .HasValue<Message>(Guid.Parse("939cf108-1886-402d-8dae-130f21d36378"))
                .HasValue<OutgoingMessage>(Guid.Parse("6a3690f2-69f4-4a97-8160-ec4e8c84528b"));

            /*builder
                .Property<Guid>("_messageType")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Discriminator")
                .IsRequired();*/

            builder
                .Property<long>("SenderId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("SenderId")
                .IsRequired();

            builder
                .Property<DateTime>("CreateDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CreateDate")
                .IsRequired();

            builder
                .Property<bool>("IsLocked")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IsLocked")
                .IsRequired();

            builder
                .Property<Guid>("MessageGuid")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("MessageGuid")
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

            /*builder
                .Property<long?>("_addDocumentId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AddDocument")
                .IsRequired(false);

            builder
                .Property<long?>("_documentId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Document")
                .IsRequired(false);

            builder
                .Property<long?>("_acknowledgementId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Acknowledgement")
                .IsRequired(false);*/
        }
    }
}
