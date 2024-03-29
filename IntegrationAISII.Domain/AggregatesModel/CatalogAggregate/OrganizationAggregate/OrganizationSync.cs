using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate
{
    public class OrganizationSync : CatalogSync
    {
        private long _organizationSyncId;

        public override long EntitySyncId { get; set; }
        public OrganizationSync(long entitySyncId, long subscriberId) : base(subscriberId)
        {
            _organizationSyncId = entitySyncId > 0 ? entitySyncId : throw new IntegrationAISIIDomainException($"Invalid {nameof(entitySyncId)} ID");
        }
        public OrganizationSync() : base()
        {
        }
    }
}
