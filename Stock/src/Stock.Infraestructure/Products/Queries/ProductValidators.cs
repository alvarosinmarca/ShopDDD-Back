using FluentValidation;
using Stock.Application.Products.Commands;

namespace Stock.Infrastructure.Products.Validators
{
    /// <summary>
    /// Valida el comando
    /// </summary>
    public class ProductValidators : AbstractValidator<CreateProductCommand>
    {
    }
}
