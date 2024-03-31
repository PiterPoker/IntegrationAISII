using IntegrationAISII.Domain.AggregatesModel.MessageAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.IncomingMessageAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.OutgoingMessageAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.IncomingDocumentAggregate
{
    public class IncomingDocument : Document, IIncomingDocument
    {
        private Guid _documentKind;
        private long _messageId;
        private IncomingMessage _message;
        private long? _parentMessageId;
        private Message _parantMessage;
        private long? _mainMessageId;
        private OutgoingMessage _mainMessage;

        public IncomingDocument(IncomingMessage message, string idNumber, bool isConfident, string regNumber, int pages, DateTime regDate, Guid documentGuid, string title, long documentTypeId)
            : base(idNumber, isConfident, regNumber, pages, regDate, documentGuid, title, documentTypeId)
        {
            this._documentKind = Guid.Parse("9dc4f0a7-4983-491a-9fe7-04abb0699692");
        }

        public IncomingDocument()
            : base()
        {
            this._documentKind = Guid.Parse("9dc4f0a7-4983-491a-9fe7-04abb0699692");
        }

        public override Guid DocumentKind { get => _documentKind; }

        public override Message ParentMessage { get => _parantMessage; }

        public override OutgoingMessage MainMessage { get => _mainMessage; }
        public override Message Message { get => _message; }

        public OutgoingMessage GetMainMessageAsIncomingDocument() => _mainMessage;

        public void SetParentMessage(Message parentMessage) => _parantMessage = parentMessage;
        public void SetMainMessage(OutgoingMessage mainMessage) => _mainMessage = mainMessage;
    }
}
