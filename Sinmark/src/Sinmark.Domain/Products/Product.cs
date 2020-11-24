using System;
using System.Collections.Generic;
using SharedKernel.Domain.Aggregates;

namespace Sinmark.Domain.Products
{
    internal class Product : AggregateRootAuditable<Guid>
    {
        private readonly ICollection<Image> _images; // Capado friki, y ponerlo en el binding de EF, para mongo a saber si funciona

        private Product()
        {
            _images = new HashSet<Image>();
        }

        public static Product Create(Guid id)
        {
            var product = new Product
            {
                Id = id
            };

            product.Record(new ProductCreatedEvent(id.ToString())); // Aquí añado eventos al agregado raíz, después inyectas IEventBus y le pasas estos eventos

            return product;
        }

        public string Description { get; private set; }

        public decimal BasePrice { get; private set; }

        public bool Visible { get; private set; }

        /// <summary>
        /// https://medium.com/developers-arena/ienumerable-vs-icollection-vs-ilist-vs-iqueryable-in-c-2101351453db
        /// </summary>
        public IEnumerable<Image> Images => _images; // De esta forma no pueden hacer .Add(), con ICollection si pueden hacer .Add()

        public Product SetDescription(string description)
        {
            // TODO: Validations con fluent validations
            // TODO: Aquí puedo lanzar un evento que ocurran al realizar este cambio
            Description = description;
            return this;
        }

        public Product AddImage(Guid id, string path)
        {
            _images.Add(Image.Create(this, id, path));
            return this;
        }
    }
}
