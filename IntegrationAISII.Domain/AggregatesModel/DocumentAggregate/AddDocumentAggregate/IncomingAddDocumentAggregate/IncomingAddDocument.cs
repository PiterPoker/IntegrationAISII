﻿using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.IncomingDocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.IncomingMessageAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate.IncomingAddDocumentAggregate
{
    public class IncomingAddDocument : AddDocument, IIncomingAddDocument
    {
        private long? _mainDocumentId;
        private IncomingDocument _mainDocument;
        private Guid _addDocumentType;
        private long _incomingMessageId;
        private IncomingMessage _message;

        protected IncomingAddDocument(Guid addDocumentGuid, int addTypeId, string content) 
            : base(addDocumentGuid, addTypeId, content)
        {
            _addDocumentType = Guid.Parse("cae8ef83-8c91-46b1-a3c0-75a5fecaf624");
        }

        public IncomingAddDocument(IncomingMessage incomingMessage, Guid addDocumentGuid, int addTypeId, string content) 
            : this(addDocumentGuid, addTypeId, content)
        {
            this._message = incomingMessage;
        }
        public IncomingAddDocument()
            : base()
        {
            _addDocumentType = Guid.Parse("cae8ef83-8c91-46b1-a3c0-75a5fecaf624");
        }

        public override Guid AddDocumentType { get => _addDocumentType; }

        public override IncomingDocument MainDocument { get => _mainDocument; }

        public override IncomingMessage Message { get => _message; }

        public void SetMainDocument(IncomingDocument document)
        {
            this._mainDocument = document;
        }
    }
}
