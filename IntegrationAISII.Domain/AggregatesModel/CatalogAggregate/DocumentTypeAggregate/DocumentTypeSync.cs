using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.DocumentTypeAggregate
{
    public class DocumentTypeSync : CatalogSync
    {
        private long _documentType;
        public override long EntitySyncId { get => _documentType; }
        public DocumentTypeSync(long entitySyncId, long subscriberId) 
            : base(subscriberId)
        {
            _documentType = entitySyncId > 0 ? entitySyncId : throw new IntegrationAISIIDomainException($"Invalid {nameof(entitySyncId)} ID");
        }
    }
}
