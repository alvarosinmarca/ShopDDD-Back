using System.Threading;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SharedKernel.Application.Cqrs.Commands;
using Stock.Application.Products.Commands;

namespace Stock.Api.Controllers
{
    // TODO BUSCAR: https://stackoverflow.com/questions/53505197/net-core-2-1-swashbuckle-group-controllers-by-area

    [Route("api/[controller]")]
    [ApiController]
    public partial class ProductsController : ControllerBase
    {

        // FromServices = Inyección por método, no inyectar en la clase, porque tenemos muchos métodos distintos

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromServices] ICommandBus commandBus, [FromBody] CreateProductCommand createProductCommand, CancellationToken cancellationToken)
        {
            await commandBus.Dispatch(createProductCommand, cancellationToken);
            return Ok();
        }

    }
}
