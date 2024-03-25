using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate.OutgoingAddDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.OutgoingDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.IncomingMessageAggregate;

namespace IntegrationAISII.Domain.AggregatesModel.MessageAggregate.OutgoingMessageAggregate
{
    public class OutgoingMessage : Message, IOutgoingMessage
    {
        private Guid _messageType;
        private Guid _messageGuid;
        private List<Receiver> _receivers;

        public OutgoingMessage(string subject, long? subscriberId)
            : base(subject, subscriberId)
        {
            this._messageGuid = Guid.NewGuid();
            this._messageType = Guid.Parse("6a3690f2-69f4-4a97-8160-ec4e8c84528b");
            this._receivers = new List<Receiver>();
        }

        public override Guid MessageGuid { get => _messageGuid; }
        public override Guid MessageType { get => _messageType; }
        public IEnumerable<Receiver> Receivers { get => _receivers; }
        public OutgoingAddDocument AddDocument { get; private set; }
        public OutgoingDocument Document { get; private set; }

        public void AddReceiver(IOrganization organization)
        {
            if (organization is null)
                throw new IntegrationAISIIDomainException($"Invalid {nameof(organization)} must not be null");

            this.AddReceiver(organization.Id);
        }

        public void AddReceiver(long organizationId)
        {
            if (organizationId < 0)
                throw new IntegrationAISIIDomainException($"Invalid {nameof(organizationId)} must not be less zero");

            if(_receivers.Count > 100)
                throw new IntegrationAISIIDomainException($"Maximum number of {nameof(_receivers)} execeeded. Maximum count equals 100");

            var receiver = this._receivers.SingleOrDefault(r => r.CompareByOrganizationId(organizationId));

            if (receiver is null)
            {
                var newReceiver = new Receiver(this, organizationId);

                this._receivers.Add(newReceiver);
            }
        }

        public void AddMailingTrackForReceiver(long organizationId, TrackingStatuses status)
        {
            if (organizationId < 0)
                throw new IntegrationAISIIDomainException($"Invalid {nameof(organizationId)} must not be less zero");

            var receiver = this._receivers.SingleOrDefault(r => r.CompareByOrganizationId(organizationId));

            if (receiver is null)
                throw new IntegrationAISIIDomainException($"Invalid {nameof(receiver)} not found");

            receiver.AddOutgoingMailingTrack(status);
        }

        public void SetIncomingDocumnet(string idNumber, bool isConfident, string regNumber, int pages, DateTime regDate, Guid documentGuid, string title, long documentTypeId)
        {
            this.SetIncomingDocumnet(idNumber, isConfident, regNumber, pages, regDate, documentGuid, title, documentTypeId, null);
        }

        public void SetIncomingDocumnet(string idNumber, bool isConfident, string regNumber, int pages, DateTime regDate, Guid documentGuid, string title, long documentTypeId, IncomingMessage mainMessage)
        {
            this.SetIncomingDocumnet(idNumber, isConfident, regNumber, pages, regDate, documentGuid, title, documentTypeId, mainMessage, null);
        }

        public void SetIncomingDocumnet(string idNumber, bool isConfident, string regNumber, int pages, DateTime regDate, Guid documentGuid, string title, long documentTypeId, IncomingMessage mainMessage, Message parentMessage)
        {
            if (Document is null)
            {
                Document = new OutgoingDocument(this, idNumber, isConfident, regNumber, pages, regDate, title, documentTypeId);
            }
            else
            {
                Document.SetIdNumber(idNumber);
                Document.SetIsConfident(isConfident);
                Document.SetRegNumber(regNumber);
                Document.SetPages(pages);
                Document.SetRegDate(regDate);
                Document.SetDocumentTypeId(documentTypeId);
            }

            if (mainMessage is not null)
                Document.SetMainMessage(mainMessage);

            if (parentMessage is not null)
                Document.SetParentMessage(parentMessage);

            if (AddDocument is not null)
            {
                AddDocument.SetMainDocument(Document);
            }
        }

        public void SetIncomingAddDocument(TypeMaterial addType, string content)
        {
            if (AddDocument is null)
            {
                this.AddDocument = new OutgoingAddDocument(this, addType.Id, content);
            }
            else
            {
                AddDocument.SetAddType(addType.Id);
                AddDocument.SetContent(content);
            }

            if (this.Document is not null)
            {
                this.AddDocument.SetMainDocument(Document);
            }
        }
    }
}
