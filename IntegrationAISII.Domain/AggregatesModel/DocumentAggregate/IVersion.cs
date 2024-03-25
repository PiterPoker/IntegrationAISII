using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.FileTypeAggregate;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate
{
    public interface IVersion
    {
        long Id { get; }
        string FileName { get; }
        FileType FileType { get; }
        string Noname { get; }
        IEnumerable<Signature> Signatures { get; }
    }
}