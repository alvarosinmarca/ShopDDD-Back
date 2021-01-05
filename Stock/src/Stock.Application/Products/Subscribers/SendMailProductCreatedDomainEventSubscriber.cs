using System;
using System.Threading;
using System.Threading.Tasks;
using SharedKernel.Application.Events;
using Stock.Domain.Products.Events;

namespace Stock.Application.Products.Subscribers
{
    internal class SendMailProductCreatedDomainEventSubscriber : DomainEventSubscriber<ProductCreatedDomainEvent>
    {
        protected override Task On(ProductCreatedDomainEvent @event, CancellationToken cancellationToken)
        {
            Console.WriteLine("Event ProductCreatedDomainEvent executed");
            return Task.CompletedTask;
        }
    }
}
