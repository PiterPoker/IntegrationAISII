using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate;

namespace IntegrationAISII.Domain.AggregatesModel.MessageAggregate.IncomingMessageAggregate
{
    public interface IIncomingMessage : IMessage
    {
        Organization Sender { get; }
    }
}