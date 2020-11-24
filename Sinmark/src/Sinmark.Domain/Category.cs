using System;
using SharedKernel.Domain.Entities;

namespace Sinmark.Domain
{
    internal class Category : EntityAuditable<Guid>
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
