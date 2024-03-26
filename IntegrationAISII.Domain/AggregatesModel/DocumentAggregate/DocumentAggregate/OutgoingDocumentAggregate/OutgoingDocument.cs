using IntegrationAISII.Domain.AggregatesModel.MessageAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.IncomingMessageAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.OutgoingMessageAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.OutgoingDocumentAggregate
{
    public class OutgoingDocument : Document, IOutgoingDocument
    {
        private Guid _documentKind;
        private Guid _documentGuid;
        private Message _parantMessage;
        private IncomingMessage _mainMessage;

        public OutgoingDocument(OutgoingMessage message, string idNumber, bool isConfident, string regNumber, int pages, DateTime regDate, string title, long documentTypeId)
            : base(message, idNumber, isConfident, regNumber, pages, regDate, title, documentTypeId)
        {
            this._documentGuid = Guid.NewGuid();
            this._documentKind = Guid.Parse("8e6389d8-78da-489d-865e-b4b9ecc4dda0");
        }

        public override Guid DocumentKind { get => _documentKind; }
        public override Guid DocumentGuid { get => _documentGuid; }

        public override Message ParentMessage { get => _parantMessage; }

        public override IncomingMessage MainMessage { get => _mainMessage; }

        public IncomingMessage GetMainMessageAsOutgoingMessage() => _mainMessage;

        public void SetParentMessage(Message parentMessage) => _parantMessage = parentMessage;
        public void SetMainMessage(IncomingMessage mainMessage) => _mainMessage = mainMessage;
    }
}
