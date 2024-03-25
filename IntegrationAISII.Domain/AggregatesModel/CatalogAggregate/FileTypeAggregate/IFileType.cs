namespace IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.FileTypeAggregate
{
    public interface IFileType : ICatalog
    {
        string Extension { get; }
    }
}