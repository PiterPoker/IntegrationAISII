using MediatR;
using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.DocumentTypeAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.Events.CatalogEvents.DocumentTypeEvents
{
    public class DocumentTypeAddedNewTypeEvent 
        : INotification
    {
        public DocumentType DocumentType { get; private set; }

        public DocumentTypeAddedNewTypeEvent(DocumentType documentType)
        {
            DocumentType = documentType;
        }
    }
}
