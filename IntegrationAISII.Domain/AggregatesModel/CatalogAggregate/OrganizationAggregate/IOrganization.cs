namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate
{
    public interface IOrganization : ICatalog
    {
        string AbonentBox { get; }
        string Corpus { get; }
        long EdmsTypeId { get; }
        string Email { get; }
        string Fax { get; }
        string Home { get; }
        string Phone { get; }
        string PostIndex { get; }
        string ShortName { get; }
        string SmdoCode { get; }
        string Soato { get; }
        string Street { get; }
        string Unp { get; }
    }
}