using IntegrationAISII.Domain.AggregatesModel.CatalogAggregate.OrganizationAggregate;

namespace IntegrationAISII.Domain.AggregatesModel.MessageAggregate.IncomingMessageAggregate
{
    public interface IIncomingMessage : IMessage
    {
        public Organization Sender { get; }
    }
}