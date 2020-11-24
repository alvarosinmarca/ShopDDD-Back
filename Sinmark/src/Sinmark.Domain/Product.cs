using SharedKernel.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Sinmark.Domain
{
    internal class Product : EntityAuditable<Guid>
    {
        public string Description { get; }

        public decimal BasePrice { get; }

        public bool Visible { get; }

        /// <summary>
        /// https://medium.com/developers-arena/ienumerable-vs-icollection-vs-ilist-vs-iqueryable-in-c-2101351453db
        /// </summary>
        public IEnumerable<Image> Images { get; }
    }
}
