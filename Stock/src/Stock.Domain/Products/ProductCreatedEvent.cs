using SharedKernel.Domain.Events;

namespace Stock.Domain.Products
{
    internal class ProductCreatedEvent : DomainEvent
    {
        // eventId si es null se autogenera y la fecha igual
        public ProductCreatedEvent(string aggregateId, string eventId = null, string occurredOn = null): base(aggregateId, eventId, occurredOn)
        {
        }
    }
}
