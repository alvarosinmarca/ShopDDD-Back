using System;
using SharedKernel.Domain.Entities.Globalization;

namespace Blog.Domain
{
    // TODO ALVARO: Esto tiene que ser multi-idioma
    // TODO ALVARO: ¿Y Si quiero etiquetar con las mismas etiquetas Blog.Domain.Posts y Stock.Domain.Products?

    internal class Tag: EntityIsTranslatable<Guid,Tag,Translatable>
    {

    }

    /// <summary>
    /// Crea tabla TAG y translatable
    /// </summary>
    internal class Translatable : EntityTranslated<Guid,Tag>
    {
        public string Name { get; }
    }
}
