using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.IncomingMessageAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.EntityConfigurations
{
    internal class IncomingMessageEntityTypeConfiguration
        : IEntityTypeConfiguration<IncomingMessage>
    {
        public void Configure(EntityTypeBuilder<IncomingMessage> builder)
        {
            /*builder.ToTable("messages", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("messages_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder
                .Property<Guid>("_messageType")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Discriminator")
                .IsRequired();

            builder
                .Property<long>("_senderId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("SenderId")
                .IsRequired();

            builder
                .Property<DateTime>("_createDate")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("CreateDate")
                .IsRequired();

            builder
                .Property<bool>("_isLocked")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("IsLocked")
                .IsRequired();

            builder
                .Property<Guid>("_messageGuid")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("MessageGuid")
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
                .Property<long?>("_addDocumentId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AddDocumentId")
                .IsRequired();

            builder
                .Property<long?>("_documentId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("DocumentId")
                .IsRequired();

            builder
                .Property<long?>("_acknowledgementId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("AcknowledgementId")
                .IsRequired();*/

            /*builder
                .HasOne(u => u.AddDocument)
                .WithOne()
                .HasForeignKey("MessageId")
                .IsRequired(false);

            builder
                .HasOne(u => u.Document)
                .WithOne()
                .HasForeignKey("MessageId")
                .IsRequired(false);

            builder
                .HasOne(u => u.Acknowledgement)
                .WithOne()
                .HasForeignKey("MessageId")
                .IsRequired(false);*/

            builder
                .HasMany(b => b.MailingTracks)
                .WithOne()
                .HasForeignKey("MessageId")
                .OnDelete(DeleteBehavior.Restrict);

            var mailingTracks = builder.Metadata.FindNavigation(nameof(IncomingMessage.MailingTracks));

            mailingTracks.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
