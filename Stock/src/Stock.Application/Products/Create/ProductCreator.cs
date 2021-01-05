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

        public Task Create(Guid id, CancellationToken cancellationToken)
        {
            var product = Product.Create(id);
            _productRepository.Add(product);
            _productRepository.SaveChanges(); // He depurado y el SaveChanges internamente hace un PullDomainEvents y el product.PullDomainEvents() contiene 0 eventos al ejecutar el SaveChanges()

            return _eventBus.Publish(product.PullDomainEvents(), cancellationToken);
        }
    }
}
