using System.Threading;
using System.Threading.Tasks;
using SharedKernel.Application.Communication.Email;
using SharedKernel.Application.Events;
using Stock.Domain.Products.Events;

namespace Stock.Application.Products.Subscribers
{
    internal class SendMailProductCreatedDomainEventSubscriber : DomainEventSubscriber<ProductCreatedDomainEvent>
    {
        private readonly IEmailSender _emailSender;

        public SendMailProductCreatedDomainEventSubscriber(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        protected override async Task On(ProductCreatedDomainEvent @event, CancellationToken cancellationToken)
        {
            await _emailSender.SendEmailAsync("target@target.com", "Event ProductCreatedDomainEvent executed", @event.EventId);
        }
    }
}
