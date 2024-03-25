namespace IntegrationAISII.Domain.AggregatesModel.DocumentAggregate
{
    public interface ISignature
    {
        long Id { get; }
        string Signer { get; }
        DateTime SignTime { get; }
        byte[] Value { get; }
    }
}