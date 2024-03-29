using IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate;
using IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.OutgoingAcknowledgementAggregate;
using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate.OutgoingAddDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate;
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
        private long? _addDocumentId;
        private OutgoingAddDocument _addDocument;
        private long? _documentId;
        private OutgoingDocument _document;
        private long? _acknowledgementId;
        private OutgoingAcknowledgement _acknowledgement;

        public OutgoingMessage(string subject, long? subscriberId)
            : base(subject, subscriberId)
        {
            this._messageGuid = Guid.NewGuid();
            this._messageType = Guid.Parse("6a3690f2-69f4-4a97-8160-ec4e8c84528b");
            this._receivers = new List<Receiver>();
        }

        public OutgoingMessage() { }

        public override Guid MessageGuid { get => _messageGuid; }
        public override Guid MessageType { get => _messageType; }
        public IEnumerable<Receiver> Receivers { get => _receivers; }
        public override OutgoingAddDocument AddDocument { get => _addDocument; }
        public override OutgoingDocument Document { get => _document; }
        public override OutgoingAcknowledgement Acknowledgement { get => _acknowledgement; }

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

        public void AddMailingTrackForReceiver(long organizationId, TrackingStatus status)
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
            if (_document is null)
            {
                _document = new OutgoingDocument(this, idNumber, isConfident, regNumber, pages, regDate, title, documentTypeId);
            }
            else
            {
                _document.SetIdNumber(idNumber);
                _document.SetIsConfident(isConfident);
                _document.SetRegNumber(regNumber);
                _document.SetPages(pages);
                _document.SetRegDate(regDate);
                _document.SetDocumentTypeId(documentTypeId);
            }

            if (mainMessage is not null)
                _document.SetMainMessage(mainMessage);

            if (parentMessage is not null)
                _document.SetParentMessage(parentMessage);

            if (_addDocument is not null)
            {
                _addDocument.SetMainDocument(_document);
            }
        }

        public void SetIncomingAddDocument(TypeMaterial addType, string content)
        {
            if (_addDocument is null)
            {
                this._addDocument = new OutgoingAddDocument(this, addType.Id, content);
            }
            else
            {
                _addDocument.SetAddType(addType.Id);
                _addDocument.SetContent(content);
            }

            if (this._document is not null)
            {
                this._addDocument.SetMainDocument(_document);
            }
        }
    }
}
