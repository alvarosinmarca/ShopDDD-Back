using SharedKernel.Domain.Entities;

namespace Blog.Domain
{
    internal class Image : EntityAuditable<Guid>
    {
        public string FileName { get; }

        public string Description { get; }
    }
}
