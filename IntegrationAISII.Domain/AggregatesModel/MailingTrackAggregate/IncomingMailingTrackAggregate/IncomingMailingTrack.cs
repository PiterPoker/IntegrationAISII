using IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.IncomingAcknowledgementAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.IncomingMessageAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate.IncomingMailingTrackAggregate
{
    public class IncomingMailingTrack : MailingTrack, IIncomingMailingTrack
    {
        private Guid _typeGuid;
        private long? _messageId;
        private IncomingMessage _message;
        private long? _acknowledgementId;
        private IncomingAcknowledgement _acknowledgement;

        public override IncomingAcknowledgement Acknowledgement { get => _acknowledgement; }
        public IncomingMessage Message { get => _message; }

        public IncomingMailingTrack(DateTime createDate)
            : base(createDate)
        {
            _typeGuid = Guid.Parse("5d2eab5f-7ebc-4782-8994-6c9497a8ab0d");
        }

        public IncomingMailingTrack(IncomingMessage incomingMessage, DateTime createDate)
            : this(createDate)
        {
            this._message = incomingMessage;
        }

        public IncomingMailingTrack(IncomingAcknowledgement acknowledgement, DateTime createDate)
            : this(createDate)
        {
            _acknowledgement = acknowledgement;
        }
        public IncomingMailingTrack()
            : base()
        {
            _typeGuid = Guid.Parse("5d2eab5f-7ebc-4782-8994-6c9497a8ab0d");
        }

        public override Guid TypeGuid { get => this._typeGuid; }
    }
}
