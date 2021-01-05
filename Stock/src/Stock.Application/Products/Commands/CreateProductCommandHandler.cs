using SharedKernel.Application.Cqrs.Commands.Handlers;
using System.Threading;
using System.Threading.Tasks;
using Stock.Application.Products.Create;

namespace Stock.Application.Products.Commands
{
    internal class CreateProductCommandHandler : ICommandRequestHandler<CreateProductCommand>
    {
        private readonly ProductCreator _productCreator;

        public CreateProductCommandHandler(ProductCreator productCreator)
        {
            _productCreator = productCreator;
        }

        public Task Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            return _productCreator.Create(command.Id, cancellationToken);
        }
    }
}
