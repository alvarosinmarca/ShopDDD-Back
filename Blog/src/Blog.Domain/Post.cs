using System;
using System.Collections.Generic;
using SharedKernel.Domain.Entities;

namespace Blog.Domain
{
    internal class Post: EntityAuditable<Guid>
    {
        public string Title { get; }

        public string Body { get; }

        public bool Visible { get; }

        public IEnumerable<Tag> Tags { get; }
    }
}
