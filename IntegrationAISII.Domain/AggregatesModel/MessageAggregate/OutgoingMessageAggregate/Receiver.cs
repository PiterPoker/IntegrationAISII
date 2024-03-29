using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate;
using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate;
using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate.OutgoingMailingTrackAggregate;
using IntegrationAISII.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationAISII.Domain.AggregatesModel.MessageAggregate.OutgoingMessageAggregate
{
    public class Receiver : Entity
    {
        private long _orgainizationId;
        private Organization _orgainization;
        private long _messageId;
        private OutgoingMessage _message;
        private List<OutgoingMailingTrack> _mailingTracks;

        public Organization Organization { get => _orgainization; }
        public List<OutgoingMailingTrack> MailingTracks { get => _mailingTracks; }

        public Receiver(OutgoingMessage message, long orgainizationId)
            : this()
        {
            _message = message is not null ? message : throw new ArgumentNullException(nameof(message));
            _orgainizationId = orgainizationId > 0 ? orgainizationId : throw new IntegrationAISIIDomainException($"Invalid {nameof(orgainizationId)} ID");
        }

        public Receiver()
        {
            _mailingTracks = new List<OutgoingMailingTrack>()
            {
                new OutgoingMailingTrack(this, DateTime.UtcNow)
            };
        }

        public bool CompareByOrganizationId(long organizationId) => this._orgainizationId == organizationId;

        public void AddOutgoingMailingTrack(TrackingStatus status)
        {
            var statusExists = _mailingTracks.SingleOrDefault(mt=>mt.Value == status);
            if (statusExists is null)
            {
                var newStatus = new OutgoingMailingTrack(this, DateTime.UtcNow);
                newStatus.ChangeStatus(status);
                _mailingTracks.Add(newStatus);
            }
        }
    }
}
