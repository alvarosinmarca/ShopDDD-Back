using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure.Data.EntityFrameworkCore.DbContexts;

namespace Stock.Infrastructure.Data.EFCore
{
    public class StockDbContext : DbContextBase
    {
        // typeof(StockDbContext).Assembly Ahorramos los mappings de EregesUnitOfWork
        public StockDbContext(DbContextOptions options, IAuditableService auditableService) : 
            base(options, "stock", typeof(StockDbContext).Assembly, auditableService, null)
        {

        }
    }
}
