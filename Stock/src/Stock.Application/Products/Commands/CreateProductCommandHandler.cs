using System.Threading;
using System.Threading.Tasks;
using SharedKernel.Domain.Events;
using Stock.Domain.Products;

namespace Stock.Application.Products.Commands
{
    // Comando por memoria
    // Event por rabbit

    internal class CreateProductCommandHandler : SharedKernel.Application.Cqrs.Commands.Handlers.ICommandRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IEventBus _eventBus;

        public CreateProductCommandHandler(IProductRepository productRepository, IEventBus eventBus)
        {
            _productRepository = productRepository;
            _eventBus = eventBus;
        }

        public Task Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var productCreate = Product.Create(command.Id);

            _productRepository.Add(productCreate);

            _productRepository.SaveChanges(); // Aquí podrías hacer UnitOfWork y grabarías

            return _eventBus.Publish(productCreate.PullDomainEvents(), cancellationToken);

        }
    }
}
