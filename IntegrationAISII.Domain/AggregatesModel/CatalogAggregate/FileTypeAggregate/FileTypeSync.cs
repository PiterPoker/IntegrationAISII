using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.FileTypeAggregate
{
    public class FileTypeSync : CatalogSync
    {
        private long _fileTypeSyncId;

        public override long EntitySyncId { get; set; }
        public FileTypeSync(long entitySyncId, long subscriberId) : base(subscriberId)
        {
            _fileTypeSyncId = entitySyncId > 0 ? entitySyncId : throw new IntegrationAISIIDomainException($"Invalid {nameof(entitySyncId)} ID");
        }
        public FileTypeSync() 
            : base()
        {
        }

    }
}
