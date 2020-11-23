using System;
using SharedKernel.Domain.Entities;

namespace Sinmark.Domain
{
    internal class Image : EntityAuditable<Guid>
    {
        internal string FileName { get; }
        internal string Description { get; }
        internal bool IsPrincipal { get; }
    }
}
