using IntegrationAISII.Domain.Events.CatalogEvents.SedTypeEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.SedTypeAggregate
{
    public class SedType : Catalog, ISedType
    {
        private string _version;
        private string _description;
        private List<SedTypeSync> _sedTypeSyncs;

        /// <summary>
        /// Версия ВСЭД
        /// </summary>
        public string Version { get => _version; }
        /// <summary>
        /// Развернутое описание ВСЭД
        /// </summary>
        public string Description { get => _description; }
        public IEnumerable<SedTypeSync> SedTypeSyncs { get => _sedTypeSyncs; }
        public SedType(Guid objid, DateTime createDate, string name, bool isActual, Guid aisiiId, string version, string description)
            : base(objid, createDate, name, isActual, aisiiId)
        {
            _version = !string.IsNullOrWhiteSpace(version) ? version : throw new IntegrationAISIIDomainException($"Invalid {nameof(version)} must not be empty");
            _description = !string.IsNullOrWhiteSpace(description) ? description : throw new IntegrationAISIIDomainException($"Invalid {nameof(description)} must not be empty");
            _sedTypeSyncs = new List<SedTypeSync>();

            this.EntitySyncAllSubscribers();
        }
        public SedType(ISedType sedType) 
            : this(sedType.ObjId, sedType.CreateDate, sedType.Name, sedType.IsActual, sedType.AisiiId, sedType.Version, sedType.Description)
        {
        }
        public SedType() 
            : base()
        {
        }

        public override void EntitySync(long subscriberId)
        {
            if (subscriberId <= 0)
                throw new IntegrationAISIIDomainException($"Invalid {nameof(subscriberId)}");

            var sedTypeSync = _sedTypeSyncs.SingleOrDefault(t => t.Id == subscriberId);

            if (sedTypeSync is null)
            {
                throw new IntegrationAISIIDomainException($"Invalid {nameof(sedTypeSync)} not found");
            }

            sedTypeSync.SetIsSync(true);
        }

        private protected override void EntitySyncAllSubscribers()
        {
            this.AddDomainEvent(new SedTypeAddedNewTypeEvent(this));
        }
    }
}
