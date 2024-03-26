
namespace IntegrationAISII.Domain.AggregatesModel.MailingTrackAggregate
{
    public interface IMailingTrack
    {
        long Id { get; }
        Guid TypeGuid { get; }
        DateTime CreateDate { get; }
        string Description { get; }
        bool IsUnread { get; }
        TrackingStatus Value { get; }
    }
}