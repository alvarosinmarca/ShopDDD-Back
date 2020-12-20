using System.Threading;
using System.Threading.Tasks;
using SharedKernel.Application.Events;
using Stock.Domain.Products;

namespace Stock.Application.Products.Suscribers
{
    internal class SendMailProductCreatedSubscriber : DomainEventSubscriber<ProductCreatedEvent>
    {
        protected override Task On(ProductCreatedEvent @event, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
