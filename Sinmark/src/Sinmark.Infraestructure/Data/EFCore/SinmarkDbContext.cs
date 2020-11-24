using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure.Data.EntityFrameworkCore.DbContexts;

namespace Sinmark.Infraestructure.Data.EFCore
{
    public class SinmarkDbContext : DbContextBase
    {
        // typeof(SinmarkDbContext).Assembly Ahorramos los mappings de EregesUnitOfWork
        public SinmarkDbContext(DbContextOptions options, IAuditableService auditableService) : 
            base(options, "stock", typeof(SinmarkDbContext).Assembly, auditableService, null)
        {

        }
    }
}
