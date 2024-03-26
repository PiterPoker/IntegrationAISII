using IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate;
using IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.IncomingAcknowledgementAggregate;
using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate.IncomingAddDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate;
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
        private Organization _sender;
        private long? _addDocumentId;
        private IncomingAddDocument _addDocument;
        private long? _documentId;
        private IncomingDocument _document;
        private long? _acknowledgementId;
        private IncomingAcknowledgement _acknowledgement;

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
        public Organization Sender { get => _sender; }
        public override AddDocument AddDocument { get => _addDocument; }
        public override Document Document { get => _document;  }
        public override Acknowledgement Acknowledgement { get => _acknowledgement; }
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
            if (_document is null) 
            {
                _document = new IncomingDocument(this, idNumber, isConfident, regNumber, pages, regDate, documentGuid, title, documentTypeId);
            }
            else
            {
                _document.SetIdNumber(idNumber);
                _document.SetIsConfident(isConfident);
                _document.SetRegNumber(regNumber);
                _document.SetPages(pages);
                _document.SetRegDate(regDate);
                _document.SetDocumentGuid(documentGuid);
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

        public void SetIncomingAddDocument(Guid addDocumentGuid, TypeMaterial addType, string content)
        {
            if (_addDocument is null) 
            {
                this._addDocument = new IncomingAddDocument(this, addDocumentGuid, addType.Id, content);
            }
            else
            {
                _addDocument.SetAddDocumentGuid(addDocumentGuid);
                _addDocument.SetAddType(addType.Id);
                _addDocument.SetContent(content);
            }

            if(this._document is not null)
            {
                this._addDocument.SetMainDocument(_document);
            }
        }

        public void AddMailingTrackForSender(TrackingStatus status)
        {
            if (Sender is null)
                throw new ArgumentNullException(nameof(Sender));

            var incomingMailingTrack = new IncomingMailingTrack(this, DateTime.UtcNow);
            incomingMailingTrack.ChangeStatus(status);
            
            _mailingTracks.Add(incomingMailingTrack);
        }

        public void SetIncomingAcknowledgement(OutgoingMessage outgoingMessage, Guid ackMessageGuid, string subject, string errorText, int errorCode)
        {
            if (_acknowledgement is null)
            {
                this._acknowledgement = new IncomingAcknowledgement(this, outgoingMessage, ackMessageGuid, subject, errorText, errorCode);
            }
        }

        public void SetIncomingAcknowledgement(Guid ackMessageGuid, string subject, string errorText, int errorCode)
        {
            if (_acknowledgement is null)
            {
                throw new ArgumentNullException(nameof(_acknowledgement));
            }

            _acknowledgement.SetAckMessageGuid(ackMessageGuid);
            _acknowledgement.SetSubject(subject);
            _acknowledgement.SetErrorText(errorText);
            _acknowledgement.SetErrorCode(errorCode);
        }
    }
}
