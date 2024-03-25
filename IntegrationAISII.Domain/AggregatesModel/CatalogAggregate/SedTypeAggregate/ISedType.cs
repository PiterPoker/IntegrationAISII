namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.SedTypeAggregate
{
    public interface ISedType : ICatalog
    {
        string Description { get; }
        string Version { get; }
    }
}