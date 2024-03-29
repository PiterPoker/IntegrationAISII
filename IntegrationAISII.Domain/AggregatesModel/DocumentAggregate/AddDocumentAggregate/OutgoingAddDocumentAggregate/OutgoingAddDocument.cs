using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.OutgoingDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.OutgoingMessageAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate.OutgoingAddDocumentAggregate
{
    public class OutgoingAddDocument : AddDocument, IOutgoingAddDocument
    {
        private Guid _addDocumentType;
        private Guid _addDocumentGuid;
        private long? _mainDocumentId;
        private OutgoingDocument _mainDocument;
        private long _outgoingMessageId;
        private OutgoingMessage _message;

        public OutgoingAddDocument(OutgoingMessage message, int addTypeId, string content) : base(addTypeId, content)
        {
            _message = message;
            _addDocumentGuid = Guid.NewGuid();
            _addDocumentType = Guid.Parse("3d4cba68-ba9e-4b4e-ad61-487d64339e95");
        }

        public OutgoingAddDocument()
            : base()
        {
            _addDocumentGuid = Guid.NewGuid();
            _addDocumentType = Guid.Parse("3d4cba68-ba9e-4b4e-ad61-487d64339e95");
        }

        public override Guid AddDocumentType { get => _addDocumentType; }
        public override Guid AddDocumentGuid { get => _addDocumentGuid; }

        public override OutgoingDocument MainDocument { get => _mainDocument; }

        public override OutgoingMessage Message { get => _message; }

        public void SetMainDocument(OutgoingDocument document)
        {
            this._mainDocument = document;
        }
    }
}
