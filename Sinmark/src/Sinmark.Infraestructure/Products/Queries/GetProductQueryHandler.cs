using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Infrastructure.Cqrs.Queries;
using SharedKernel.Infrastructure.Data.Dapper.Queries;
using SharedKernel.Infrastructure.Data.EntityFrameworkCore.Queries;
using Sinmark.Application.Products.Queries;
using Sinmark.Domain.Products;
using Sinmark.Infraestructure.Data.EFCore;

namespace Sinmark.Infrastructure.Products.Queries
{
    // Comando por memoria
    // Event por rabbit

    internal class GetProductQueryHandler : IQueryRequestHandler<GetProductQuery, Guid>
    {
        private readonly EntityFrameworkCoreQueryProvider<SinmarkDbContext> _queryProvider;
        private readonly DapperQueryProvider<SinmarkDbContext> _dapperQueryProvider;

        // Dapper falla en memoria

        public GetProductQueryHandler(
            EntityFrameworkCoreQueryProvider<SinmarkDbContext> queryProvider, 
            DapperQueryProvider<SinmarkDbContext> dapperQueryProvider
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
