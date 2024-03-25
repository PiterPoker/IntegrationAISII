using IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.OutgoingAcknowledgementAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.OutgoingMessageAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate.OutgoingMailingTrackAggregate
{
    public class OutgoingMailingTrack : MailingTrack, IOutgoingMailingTrack
    {
        private Guid _typeGuid;
        private Receiver _receiver;
        private OutgoingAcknowledgement _outgoingAcknowledgement;

        public OutgoingMailingTrack(Receiver receiver, DateTime createDate)
            : this(createDate)
        {
            _receiver = receiver;
        }

        public OutgoingMailingTrack(OutgoingAcknowledgement outgoingAcknowledgement, DateTime createDate)
            : this(createDate)
        {
            _outgoingAcknowledgement = outgoingAcknowledgement;
        }

        public OutgoingMailingTrack(DateTime createDate)
            : base(createDate)
        {
            _typeGuid = Guid.Parse("4472ffb8-5660-4a03-9621-c94154de0866");
        }

        public override Guid TypeGuid { get => _typeGuid; }
    }
}
