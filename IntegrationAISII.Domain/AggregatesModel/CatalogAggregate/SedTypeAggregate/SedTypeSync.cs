using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.SedTypeAggregate
{
    public class SedTypeSync : CatalogSync
    {
        private long _entitySyncId;

        public override long EntitySyncId { get => _entitySyncId; }
        public SedTypeSync(long entitySyncId, long subscriberId) : base(subscriberId)
        {
            _entitySyncId = entitySyncId > 0 ? entitySyncId : throw new IntegrationAISIIDomainException($"Invalid {nameof(entitySyncId)} ID");
        }
    }
}
