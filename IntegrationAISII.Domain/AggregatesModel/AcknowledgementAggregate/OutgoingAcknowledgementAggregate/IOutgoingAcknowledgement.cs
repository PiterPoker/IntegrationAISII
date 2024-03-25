using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate.OutgoingMailingTrackAggregate;

namespace IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.OutgoingAcknowledgementAggregate
{
    public interface IOutgoingAcknowledgement : IAcknowledgement
    {
        IEnumerable<OutgoingMailingTrack> MailingTracks { get; }
    }
}