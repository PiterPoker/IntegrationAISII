
namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate
{
    public interface ICatalog
    {
        long Id { get; }
        Guid AisiiId { get; }
        DateTime CreateDate { get; }
        bool IsActual { get; }
        string? Name { get; }
        Guid ObjId { get; }
    }
}