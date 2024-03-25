namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate
{
    public interface ICatalogSync
    {
        long EntitySyncId { get; }
        bool IsSync { get; }
        long SubscriberId { get; }
    }
}