using System;

namespace Sinmark.Domain
{
    public class Product
    {
        protected Guid Id { get; }

        protected string Description { get; }

        protected decimal BasePrice { get; }

        protected bool Visible { get; }
    }
}
