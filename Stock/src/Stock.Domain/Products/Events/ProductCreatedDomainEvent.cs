using SharedKernel.Domain.Events;

namespace Stock.Domain.Products.Events
{
    internal class ProductCreatedDomainEvent : DomainEvent
    {
        // eventId si es null se autogenera y la fecha igual
        public ProductCreatedDomainEvent(string aggregateId, string eventId = null, string occurredOn = null) : base(aggregateId, eventId, occurredOn)
        {
        }
    }
}
