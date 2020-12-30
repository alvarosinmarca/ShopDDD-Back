using System;
using System.Threading;
using System.Threading.Tasks;
using SharedKernel.Application.Cqrs.Commands.Handlers;
using SharedKernel.Application.Logging;
//using SharedKernel.Domain.Events;
using Stock.Domain.Products;

namespace Stock.Application.Products.Commands
{
    internal class CreateProductWithReturnCommandHandler : ICommandRequestHandler<CreateProductWithReturnCommand, Guid>
    {
        private readonly IProductRepository _productRepository;

        private readonly ICustomLogger _customLogger;
        //private readonly IEventBus _eventBus;

        public CreateProductWithReturnCommandHandler(IProductRepository productRepository, ICustomLogger customLogger) // , IEventBus eventBus
        {
            _productRepository = productRepository;
            _customLogger = customLogger;
            //_eventBus = eventBus;
        }

        public Task<Guid> Handle(CreateProductWithReturnCommand command, CancellationToken cancellationToken)
        {
            var newProduct = Product.Create(command.Id);
            _productRepository.Add(newProduct);

            var registersCreated = _productRepository.SaveChanges(); // Here you can do UnitOfWork and will save

            if (registersCreated > 0)
                _customLogger.Info("Product created: " + newProduct);

            // TODO: Here will launch a event when the events work in SharedKernel
            //return _eventBus.Publish(productCreate.PullDomainEvents(), cancellationToken);

            return Task.FromResult(newProduct.Id);
        }
    }
}
