using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate;
using IntegrationAISII.Domain.AggregatesModel.MessageAggregate;

namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.AddDocumentAggregate
{
    public interface IAddDocument
    {
        long Id { get; }
        Guid AddDocumentGuid { get; }
        Guid AddDocumentType { get; }
        TypeMaterial AddType { get; }
        string Content { get; }
        Document MainDocument { get; }
        Message Message { get; }
        IEnumerable<Version> Versions { get; }
    }
}