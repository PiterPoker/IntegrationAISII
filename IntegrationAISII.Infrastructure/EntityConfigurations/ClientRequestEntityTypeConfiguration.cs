using IntegrationAISII.Infrastructure.Idempotency;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Infrastructure.EntityConfigurations
{
    internal class ClientRequestEntityTypeConfiguration
        : IEntityTypeConfiguration<ClientRequest>
    {
        public void Configure(EntityTypeBuilder<ClientRequest> builder)
        {
            builder.ToTable("requests", IntegrationAISIIContext.DEFAULT_SCHEMA);
            builder.HasKey(cr => cr.Id);
            builder.Property(cr => cr.Name).IsRequired();
            builder.Property(cr => cr.Time).IsRequired();
        }
    }
}
