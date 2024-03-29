using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate;
using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate.OutgoingMailingTrackAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.IncomingMessageAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate.OutgoingMessageAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.OutgoingAcknowledgementAggregate
{
    public class OutgoingAcknowledgement : Acknowledgement, IOutgoingAcknowledgement
    {
        private Guid _acknowledgementType;
        private Guid _ackMessageGuid;
        private OutgoingMessage _message;
        private long _outgoingMessageId;
        private long? _responseToId;
        private IncomingMessage _responseTo;
        private List<OutgoingMailingTrack> _mailingTracks;

        public OutgoingAcknowledgement(OutgoingMessage message, string subject, string errorText, int errorCode)
            : base(subject, errorText, errorCode)
        {
            _message = message;
            _ackMessageGuid = Guid.NewGuid();
            _acknowledgementType = Guid.Parse("d534e33d-ff98-4960-917a-4b8731eea3fd");
            _mailingTracks = new List<OutgoingMailingTrack>()
            {
                new OutgoingMailingTrack(this, DateTime.UtcNow),
            };
        }

        public OutgoingAcknowledgement()
            : base()
        {
            _ackMessageGuid = Guid.NewGuid();
            _acknowledgementType = Guid.Parse("d534e33d-ff98-4960-917a-4b8731eea3fd");
            _mailingTracks = new List<OutgoingMailingTrack>()
            {
                new OutgoingMailingTrack(this, DateTime.UtcNow),
            };
        }

        public override Guid AcknowledgementType { get => _acknowledgementType; }

        public override OutgoingMessage Message { get => _message; }
        public override IncomingMessage ResponseTo { get => _responseTo; }
        /// <summary>
        /// Список рассылки
        /// </summary>
        public override IEnumerable<OutgoingMailingTrack> MailingTracks { get => _mailingTracks; }
        /// <summary>
        /// Идентификатор уведомления в СМДО
        /// </summary>
        public override Guid AckMessageGuid { get => _ackMessageGuid; }

        public void AddMailingTrack(TrackingStatus status)
        {
            if (_mailingTracks is null)
                throw new ArgumentNullException(nameof(_mailingTracks));

            var mailingTrack = _mailingTracks.SingleOrDefault(mt => mt.Value == status);

            if (mailingTrack is not null)
            {
                var incomingMailingTrack = new OutgoingMailingTrack(this, DateTime.UtcNow);
                incomingMailingTrack.ChangeStatus(status);

                _mailingTracks.Add(incomingMailingTrack);
            }
        }
    }
}
