namespace NexCore.Domain.Common;

/// <summary>
/// Representa un evento que cruza los límites del bounded context,
/// publicado a través de un message broker (ej: RabbitMQ, Azure Service Bus).
/// A diferencia de IDomainEvent, es in-process; IIntegrationEvent es cross-service.
/// </summary>
public interface IIntegrationEvent
{
    Guid EventId { get; init; }
    DateTime OccurredOnUtc { get; init; }
}