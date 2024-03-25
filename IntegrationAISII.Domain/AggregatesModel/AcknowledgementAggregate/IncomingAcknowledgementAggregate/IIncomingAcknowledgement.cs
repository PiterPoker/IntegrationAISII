using IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate.IncomingMailingTrackAggregate;

namespace IntegrationAISII.Domain.AggregatesModel.AcknowledgementAggregate.IncomingAcknowledgementAggregate
{
    public interface IIncomingAcknowledgement : IAcknowledgement
    {
        IEnumerable<IncomingMailingTrack> MailingTracks { get; }
    }
}