using System.Threading;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SharedKernel.Application.Cqrs.Commands;
using Stock.Application.Products.Commands;
using System;

namespace Stock.Api.Controllers
{
    // Why partial class?: https://stackoverflow.com/questions/53505197/net-core-2-1-swashbuckle-group-controllers-by-area
    public partial class ProductsController : ControllerBase
    {
        // FromServices = Injection for method, no inject in constructor because have more methods and can break all

        /// <summary>
        /// Create a product and return the guid of DB
        /// </summary>
        [HttpPost("api/createProductWithReturn")]
        public async Task<ActionResult<Guid>> CreateProductWithReturn([FromServices] ICommandBus commandBus, [FromBody] CreateProductWithReturnCommand command, CancellationToken cancellationToken)
        {
            var response = await commandBus.Dispatch(command, cancellationToken);
            return Ok(response);
        }

    }
}
