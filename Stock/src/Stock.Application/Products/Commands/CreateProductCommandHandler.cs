using SharedKernel.Application.Cqrs.Commands.Handlers;
using Stock.Domain.Products;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Application.Products.Commands
{
    internal class CreateProductCommandHandler : ICommandRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var newProduct = Product.Create(command.Id);
            _productRepository.Add(newProduct);

            _productRepository.SaveChanges(); // Here you can do UnitOfWork and will save

            // TODO: Here will launch a event when the events work in SharedKernel
            //return _eventBus.Publish(productCreate.PullDomainEvents(), cancellationToken);

            return Task.FromResult(newProduct.Id);
        }
    }
}
