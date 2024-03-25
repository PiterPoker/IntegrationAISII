using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate.IncomingAddDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.IncomingDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate;
using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate.IncomingMailingTrackAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.OutgoingMessageAggregate;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.MessageAggregate.IncomingMessageAggregate
{
    public class IncomingMessage : Message, IIncomingMessage
    {
        private Guid _messageType;
        private List<IncomingMailingTrack> _mailingTracks;
        private long _senderId;

        public IncomingMessage(Guid packageId, string subject, long? subscriberId, long? senderId)
            : base(packageId, subject, subscriberId)
        {
            this._senderId = senderId.HasValue ? senderId.Value : throw new IntegrationAISIIDomainException($"Invalid {nameof(senderId)} must not be empty");
            this._messageType = Guid.Parse("34c9fc63-fed1-42c7-9058-fba802002613");
            _mailingTracks = new List<IncomingMailingTrack>();
        }
        public IncomingMessage(IIncomingMessage message)
            : this(message.PackageId, message.Subject, message.SubscriberId, message.Sender?.Id)
        {
        }

        public override Guid MessageType { get => _messageType; }
        public Organization Sender { get; private set; }
        public IncomingAddDocument AddDocument { get; private set; }
        public IncomingDocument Document { get; private set; }
        public IEnumerable<IncomingMailingTrack> MailingTracks { get => _mailingTracks; }

        public void SetIncomingDocumnet(string idNumber, bool isConfident, string regNumber, int pages, DateTime regDate, Guid documentGuid, string title, long documentTypeId)
        {
            this.SetIncomingDocumnet(idNumber, isConfident, regNumber, pages, regDate, documentGuid, title, documentTypeId, null);
        }

        public void SetIncomingDocumnet(string idNumber, bool isConfident, string regNumber, int pages, DateTime regDate, Guid documentGuid, string title, long documentTypeId, OutgoingMessage mainMessage)
        {
            this.SetIncomingDocumnet(idNumber, isConfident, regNumber, pages, regDate, documentGuid, title, documentTypeId, mainMessage, null);
        }

        public void SetIncomingDocumnet(string idNumber, bool isConfident, string regNumber, int pages, DateTime regDate, Guid documentGuid, string title, long documentTypeId, OutgoingMessage mainMessage, Message parentMessage)
        {
            if (Document is null) 
            {
                Document = new IncomingDocument(this, idNumber, isConfident, regNumber, pages, regDate, documentGuid, title, documentTypeId);
            }
            else
            {
                Document.SetIdNumber(idNumber);
                Document.SetIsConfident(isConfident);
                Document.SetRegNumber(regNumber);
                Document.SetPages(pages);
                Document.SetRegDate(regDate);
                Document.SetDocumentGuid(documentGuid);
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

        public void SetIncomingAddDocument(Guid addDocumentGuid, TypeMaterial addType, string content)
        {
            if (AddDocument is null) 
            {
                this.AddDocument = new IncomingAddDocument(this, addDocumentGuid, addType.Id, content);
            }
            else
            {
                AddDocument.SetAddDocumentGuid(addDocumentGuid);
                AddDocument.SetAddType(addType.Id);
                AddDocument.SetContent(content);
            }

            if(this.Document is not null)
            {
                this.AddDocument.SetMainDocument(Document);
            }
        }

        public void AddMailingTrackForSender(TrackingStatuses status)
        {
            if (Sender is null)
                throw new ArgumentNullException(nameof(Sender));

            var incomingMailingTrack = new IncomingMailingTrack(this, DateTime.UtcNow);
            incomingMailingTrack.ChangeStatus(status);
            
            _mailingTracks.Add(incomingMailingTrack);
        }
    }
}
