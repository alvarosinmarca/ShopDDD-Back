using System;
using SharedKernel.Domain.Entities;

namespace Blog.Domain
{
    // TODO ALVARO: Esto tiene que ser multi-idioma
    // TODO ALVARO: ¿Y Si quiero etiquetar con las mismas etiquetas Blog.Domain.Posts y Sinmark.Domain.Products?

    internal class Tag: EntityAuditable<Guid>
    {
        public string Name { get; }
    }
}
