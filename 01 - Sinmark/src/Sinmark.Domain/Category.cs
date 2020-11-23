using System;

namespace Sinmark.Domain
{
    public class Category
    {
        public Guid Id { get; }

        public string Name { get; }

        public string Description { get; }

        /// <summary>
        /// For SEO
        /// </summary>
        public string FriendlyUrl { get; }

        public string Visible { get; }
    }
}
