using System;
using System.Collections.Generic;
using SharedKernel.Domain.Entities;

namespace Sinmark.Domain
{
    internal class WishList: EntityAuditable<Guid>
    {
        public string Name { get; }

        public IEnumerable<Product> Products { get; }
    }
}
