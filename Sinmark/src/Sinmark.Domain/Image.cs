using System;
using SharedKernel.Domain.Entities;

namespace Sinmark.Domain
{
    internal class Image : EntityAuditable<Guid>
    {
        public string FileName { get; }

        public string Description { get; }

        public bool IsPrincipal { get; }
    }
}
