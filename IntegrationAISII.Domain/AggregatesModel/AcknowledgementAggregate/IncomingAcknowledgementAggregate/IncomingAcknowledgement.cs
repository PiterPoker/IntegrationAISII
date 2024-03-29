using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate;
using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate.IncomingMailingTrackAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.IncomingMessageAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.OutgoingMessageAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.IncomingAcknowledgementAggregate
{
    public class IncomingAcknowledgement : Acknowledgement, IIncomingAcknowledgement
    {
        private List<IncomingMailingTrack> _mailingTracks;
        private IncomingMessage _message;
        private long? _outgoingMessageId;
        private long? _responseToId;
        private OutgoingMessage _responseTo;
        private Guid _acknowledgementType;

        public IncomingAcknowledgement(IncomingMessage message, OutgoingMessage outgoingMessage, Guid ackMessageGuid, string subject, string errorText, int errorCode)
            : base(ackMessageGuid, subject, errorText, errorCode)
        {
            _responseTo = outgoingMessage ?? throw new ArgumentNullException(nameof(outgoingMessage));
            _message = message;
            _acknowledgementType = Guid.Parse("597cf4f2-99b6-427a-b3f9-4b3f6eed3b6a");
            _mailingTracks = new List<IncomingMailingTrack>()
            {
                new IncomingMailingTrack(this, DateTime.UtcNow),
            };
        }

        public IncomingAcknowledgement()
            : base()
        {
            _acknowledgementType = Guid.Parse("597cf4f2-99b6-427a-b3f9-4b3f6eed3b6a");
            _mailingTracks = new List<IncomingMailingTrack>()
            {
                new IncomingMailingTrack(this, DateTime.UtcNow),
            };
        }

        public override Guid AcknowledgementType { get => _acknowledgementType; }

        public override IncomingMessage Message { get => _message; }
        public override OutgoingMessage ResponseTo { get => _responseTo; }

        public override IEnumerable<IncomingMailingTrack> MailingTracks { get => _mailingTracks; }

        public void AddMailingTrack(TrackingStatus status)
        {
            if (_mailingTracks is null)
                throw new ArgumentNullException(nameof(_mailingTracks));

            var mailingTrack = _mailingTracks.SingleOrDefault(mt => mt.Value == status);

            if (mailingTrack is not null)
            {
                var incomingMailingTrack = new IncomingMailingTrack(this, DateTime.UtcNow);
                incomingMailingTrack.ChangeStatus(status);

                _mailingTracks.Add(incomingMailingTrack);
            }
        }
    }
}
