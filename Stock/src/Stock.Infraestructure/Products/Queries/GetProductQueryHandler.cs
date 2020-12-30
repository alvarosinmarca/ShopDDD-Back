using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure.Cqrs.Queries;
//using SharedKernel.Infrastructure.Data.Dapper.Queries;
using SharedKernel.Infrastructure.Data.EntityFrameworkCore.Queries;
using Stock.Application.Products.Queries;
using Stock.Domain.Products;
using Stock.Infrastructure.Data.EFCore;

namespace Stock.Infrastructure.Products.Queries
{
    internal class GetProductQueryHandler : IQueryRequestHandler<GetProductQuery, Guid>
    {
        private readonly EntityFrameworkCoreQueryProvider<StockDbContext> _queryProvider;
        //private readonly DapperQueryProvider<StockDbContext> _dapperQueryProvider;

        public GetProductQueryHandler(
            EntityFrameworkCoreQueryProvider<StockDbContext> queryProvider
            //DapperQueryProvider<StockDbContext> dapperQueryProvider
            )
        {
            _queryProvider = queryProvider;
            //_dapperQueryProvider = dapperQueryProvider;
        }


        public async Task<Guid> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            // Example with Dapper:
            //return await _dapperQueryProvider
            //             .ExecuteQueryFirstOrDefaultAsync<Guid>("SELECT TOP 1 Id FROM stock.product");

            return await _queryProvider
                         .GetQuery<Product>()
                         .Select(p => p.Id)
                         .Where(id => id == query.Id)
                         .SingleOrDefaultAsync(cancellationToken);

            // TODO: For pagination paginarToPagedListAsync
        }
    }
}
