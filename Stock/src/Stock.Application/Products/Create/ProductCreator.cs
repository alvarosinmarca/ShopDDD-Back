using System;
using System.Threading;
using System.Threading.Tasks;
using SharedKernel.Domain.Events;
using Stock.Domain.Products;

namespace Stock.Application.Products.Create
{
    internal class ProductCreator
    {
        private readonly IProductRepository _productRepository;
        private readonly IEventBus _eventBus;

        public ProductCreator(IProductRepository productRepository, IEventBus eventBus)
        {
            _productRepository = productRepository;
            _eventBus = eventBus;
        }

        public async Task Create(Guid id, CancellationToken cancellationToken)
        {
            var product = Product.Create(id);

            // This form break free threads if this is executed more times
            await _productRepository.AddAsync(product, cancellationToken);
            await _productRepository.SaveChangesAsync(cancellationToken);

            await _eventBus.Publish(product.PullDomainEvents(), cancellationToken);
        }
    }
}
