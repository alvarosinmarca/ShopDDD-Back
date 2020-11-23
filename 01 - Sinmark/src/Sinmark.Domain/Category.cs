using System;
using SharedKernel.Domain.Entities;

namespace Sinmark.Domain
{
    internal class Category : EntityAuditable<Guid>
    {
        internal string Name { get; }

        internal string Description { get; }

        /// <summary>
        /// For SEO
        /// </summary>
        internal string FriendlyUrl { get; }

        internal string Visible { get; }
    }
}
