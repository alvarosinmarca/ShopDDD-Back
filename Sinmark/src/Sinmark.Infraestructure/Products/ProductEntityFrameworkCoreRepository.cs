using SharedKernel.Infrastructure.Data.EntityFrameworkCore.Repositories;
using Sinmark.Domain.Products;
using Sinmark.Infraestructure.Data.EFCore;

namespace Sinmark.Infrastructure.Products
{
    internal class ProductEntityFrameworkCoreRepository : EntityFrameworkCoreRepository<Product>, IProductRepository
    {
        public ProductEntityFrameworkCoreRepository(SinmarkDbContext dbContext) : base(dbContext)
        {

        }
    }
}
