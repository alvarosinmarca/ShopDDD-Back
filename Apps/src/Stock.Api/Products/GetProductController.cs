using Microsoft.AspNetCore.Mvc;
using SharedKernel.Application.Cqrs.Queries;
using Stock.Application.Products.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stock.Api.Products
{
    public partial class ProductsController : ControllerBase
    {
        /// <summary>
        /// Get product by Id
        /// </summary>
        [HttpGet("api/getProduct")]
        public async Task<ActionResult<Guid>> GetProduct([FromServices] IQueryBus queryBus, Guid productId, CancellationToken cancellationToken)
        {
            var response = await queryBus.Ask(new GetProductQuery(productId), cancellationToken);
            return Ok(response);
        }
    }
}
