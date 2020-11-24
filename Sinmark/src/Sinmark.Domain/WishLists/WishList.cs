using System;
using System.Collections.Generic;
using SharedKernel.Domain.Entities;
using Sinmark.Domain.Products;

namespace Sinmark.Domain.WishLists
{
    internal class WishList: EntityAuditable<Guid>
    {
        public string Name { get; }

        public IEnumerable<Product> Products { get; }
    }
}
