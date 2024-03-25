namespace IntegrationAISII.Domain
{
    public class IntegrationAISIIDomainException : Exception
    {
        public IntegrationAISIIDomainException()
        { }

        public IntegrationAISIIDomainException(string message)
            : base(message)
        { }

        public IntegrationAISIIDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}