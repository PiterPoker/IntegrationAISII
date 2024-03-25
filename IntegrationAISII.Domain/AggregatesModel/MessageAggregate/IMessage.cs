namespace IntegrationAISII.Domain.AggregatesModel.MessageAggregate
{
    public interface IMessage
    {
        public long Id { get; }
        DateTime CreateDate { get; }
        bool IsLocked { get; }
        Guid MessageGuid { get; }
        Guid MessageType { get; }
        Guid PackageId { get; }
        string Subject { get; }
        long? SubscriberId { get; }
    }
}