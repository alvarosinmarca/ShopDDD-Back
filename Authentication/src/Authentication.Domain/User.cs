using SharedKernel.Domain.Entities;

namespace Authentication.Domain
{
    internal class User : EntityAuditable<Guid>
    {
        public string Name { get; }

        public string Email { get; }

        public string Password { get; }
    }
}
