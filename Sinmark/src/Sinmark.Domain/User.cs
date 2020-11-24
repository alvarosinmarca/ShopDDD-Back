using System;
using System.Collections.Generic;
using SharedKernel.Domain.Entities;

namespace Sinmark.Domain
{
    internal class User : EntityAuditable<Guid>
    {
        public string Name { get; }

        public IEnumerable<WishList> WishLists { get; }
    }
}
