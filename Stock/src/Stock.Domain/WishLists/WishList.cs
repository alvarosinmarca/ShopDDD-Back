using System;
using System.Collections.Generic;
using SharedKernel.Domain.Entities;
using Stock.Domain.Products;

namespace Stock.Domain.WishLists
{
    internal class WishList: EntityAuditable<Guid>
    {
        public string Name { get; }

        public IEnumerable<Product> Products { get; }
    }
}
