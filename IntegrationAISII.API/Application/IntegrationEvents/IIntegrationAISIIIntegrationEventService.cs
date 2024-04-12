using EventBus.Events;

namespace IntegrationAISII.API.Application.IntegrationEvents
{
    public interface IIntegrationAISIIIntegrationEventService
    {
        Task PublishEventsThroughEventBusAsync(Guid transactionId);
        Task AddAndSaveEventAsync(IntegrationEvent evt);
    }
}
