﻿using SharedKernel.Infrastructure.Data.EntityFrameworkCore.Repositories;
using Stock.Domain.Products;
using Stock.Infraestructure.Data.EFCore;

namespace Stock.Infrastructure.Products
{
    internal class ProductEntityFrameworkCoreRepository : EntityFrameworkCoreRepository<Product>, IProductRepository
    {
        public ProductEntityFrameworkCoreRepository(StockDbContext dbContext) : base(dbContext)
        {

        }
    }
}