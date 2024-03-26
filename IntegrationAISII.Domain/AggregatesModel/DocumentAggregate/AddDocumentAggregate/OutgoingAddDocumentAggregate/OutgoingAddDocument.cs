using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.OutgoingDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate;
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
        private Message _outgoingMessage;

        public OutgoingAddDocument(Message message, int addTypeId, string content) : base(message, addTypeId, content)
        {
            _addDocumentGuid = Guid.NewGuid();
            _addDocumentType = Guid.Parse("cae8ef83-8c91-46b1-a3c0-75a5fecaf624");
        }

        public override Guid AddDocumentType { get => _addDocumentType; }
        public override Guid AddDocumentGuid { get => _addDocumentGuid; }

        public override OutgoingDocument MainDocument { get => _mainDocument; }

        public override Message Message { get => _outgoingMessage; }

        public void SetMainDocument(OutgoingDocument document)
        {
            this._mainDocument = document;
        }
    }
}
