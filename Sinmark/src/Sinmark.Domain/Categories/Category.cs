using System;
using SharedKernel.Domain.Aggregates;

namespace Sinmark.Domain.Categories
{
    internal class Category : AggregateRootAuditable<Guid>
    {
        public string Name { get; }

        public string Description { get; }

        /// <summary>
        /// For SEO
        /// </summary>
        public string FriendlyUrl { get; }

        public string Visible { get; }
    }
}
