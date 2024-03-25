namespace IntegrationAISII.Domain.AggregatesModel.MessageAggregate.OutgoingMessageAggregate
{
    public interface IOutgoingMessage : IMessage
    {
        IEnumerable<Receiver> Receivers { get; }
    }
}