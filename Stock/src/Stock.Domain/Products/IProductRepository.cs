﻿using SharedKernel.Domain.Repositories;

namespace Stock.Domain.Products
{
    internal interface IProductRepository : IRepositoryAsync<Product>
    {
    }
}
