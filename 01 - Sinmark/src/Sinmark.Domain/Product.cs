using SharedKernel.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Sinmark.Domain
{
    internal class Product : EntityAuditable<Guid>
    {
        internal string Description { get; }

        internal decimal BasePrice { get; }

        internal bool Visible { get; }

        /// <summary>
        /// https://medium.com/developers-arena/ienumerable-vs-icollection-vs-ilist-vs-iqueryable-in-c-2101351453db
        /// </summary>
        internal IEnumerable<Image> Images { get; }
    }
}
