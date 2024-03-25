using IntegrationAISII.Domain.Events.CatalogEvents.DocumentTypeEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.DocumentTypeAggregate
{
    /// <summary>
    /// Модель: Справочник «Виды документов»
    /// </summary>
    public class DocumentType : Catalog, IDocumentType
    {
        private List<DocumentTypeSync> _documentTypeSyncs;
        public IEnumerable<DocumentTypeSync> DocumentTypeSyncs { get => _documentTypeSyncs; }

        public DocumentType() : base()
        {
            this._documentTypeSyncs = new List<DocumentTypeSync>();
        }
        public DocumentType(IDocumentType documentType) : this(documentType.ObjId, documentType.CreateDate, documentType.Name, documentType.IsActual, documentType.AisiiId)
        {
        }

        public DocumentType(Guid objid, DateTime createDate, string name, bool isActual, Guid aisiiId)
            : base(objid, createDate, name, isActual, aisiiId)
        {
            this._documentTypeSyncs = new List<DocumentTypeSync>();

            this.EntitySyncAllSubscribers();
        }

        public override void EntitySync(long subscriberId)
        {
            if (subscriberId <= 0)
                throw new IntegrationAISIIDomainException($"Invalid {nameof(subscriberId)}");

            var documentTypeSync = _documentTypeSyncs.SingleOrDefault(t => t.Id == subscriberId);

            if (documentTypeSync is null)
            {
                throw new IntegrationAISIIDomainException($"Invalid {nameof(documentTypeSync)} not found");
            }

            documentTypeSync.SetIsSync(true);
        }

        private protected override void EntitySyncAllSubscribers()
        {
            this.AddDomainEvent(new DocumentTypeAddedNewTypeEvent(this));
        }
    }
}
