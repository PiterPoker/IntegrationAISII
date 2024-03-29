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
    internal class ReceiverEntityTypeConfiguration
        : IEntityTypeConfiguration<Receiver>
    {
        public void Configure(EntityTypeBuilder<Receiver> builder)
        {
            builder.ToTable("receivers", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder.HasKey(cr => cr.Id);

            builder.Ignore(u => u.DomainEvents);

            builder.Property(u => u.Id)
                .UseHiLo("receivers_Id_seq", IntegrationAISIIContext.DEFAULT_SCHEMA);

            builder
                .Property<long>("_orgainizationId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Organization")
                .IsRequired();

            /*builder
                .Property<long>("_messageId")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("MessageId")
                .IsRequired();*/

            builder
                .HasMany(b => b.MailingTracks)
                .WithOne()
                .HasForeignKey("ReceiverId")
                .OnDelete(DeleteBehavior.Cascade);

            var mailingTracks = builder.Metadata.FindNavigation(nameof(Receiver.MailingTracks));

            mailingTracks.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
