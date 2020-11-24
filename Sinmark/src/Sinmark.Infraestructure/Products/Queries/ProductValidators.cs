using FluentValidation;
using Sinmark.Application.Products.Commands;

namespace Sinmark.Infrastructure.Products.Validators
{
    /// <summary>
    /// Valida el comando
    /// </summary>
    public class ProductValidators : AbstractValidator<CreateProductCommand>
    {
    }
}
