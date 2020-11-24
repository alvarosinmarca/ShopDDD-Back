using System;
using System.Threading;
using System.Threading.Tasks;
using SharedKernel.Infrastructure.Cqrs.Queries;
using SharedKernel.Infrastructure.Data.Dapper.Queries;
using SharedKernel.Infrastructure.Data.EntityFrameworkCore.Queries;
using Stock.Application.Products.Queries;
using Stock.Infraestructure.Data.EFCore;

namespace Stock.Infrastructure.Products.Queries
{
    // Comando por memoria
    // Event por rabbit

    internal class GetProductQueryHandler : IQueryRequestHandler<GetProductQuery, Guid>
    {
        private readonly EntityFrameworkCoreQueryProvider<StockDbContext> _queryProvider;
        private readonly DapperQueryProvider<StockDbContext> _dapperQueryProvider;

        // Dapper falla en memoria

        public GetProductQueryHandler(
            EntityFrameworkCoreQueryProvider<StockDbContext> queryProvider, 
            DapperQueryProvider<StockDbContext> dapperQueryProvider
            )
        {
            _queryProvider = queryProvider;
            _dapperQueryProvider = dapperQueryProvider;
        }


        public Task<Guid> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            //return _queryProvider.GetQuery<Product>().Select(p => p.Id).SingleOrDefaultAsync(cancellationToken);
            return _dapperQueryProvider.ExecuteQueryFirstOrDefaultAsync<Guid>("SELECT TOP 1 Id FROM stock.product");
            // Para paginarToPagedListAsync
        }
    }
}
