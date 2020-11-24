using System;
using SharedKernel.Domain.Entities;

namespace Sinmark.Domain.Products
{
    /// <summary>
    /// Imagen depende de un producto, porque no existe una imagen, sin antes existir un producto
    /// </summary>
    internal class Image : EntityAuditable<Guid>
    {
        private Image()
        {

        }

        /// <summary>
        /// Factoría de imágenes (Podrías crear una clase ImageFactory)
        /// </summary>
        public static Image Create(Product product, Guid id, string fileName) // Aquí pasararíamos las propiedades verdaderamente obligatorias, no tienen por qué ser todas
        {
            var image = new Image
            {
                Id = id,
                FileName = fileName,
                Product = product
            };

            // Asignar el evento al agregado raíz (En este caso Product)

            return image;
        }

        public string FileName { get; private set; }

        public string Description { get; private set; }

        public bool IsPrincipal { get; private set; }

        #region Properties navigation (EF)

        public Guid ProductId { get; private set; } // Por si quieres cambiarlo al buelo sin pasar por el objeto Product

        public Product Product { get; private set; }

        #endregion
    }
}
