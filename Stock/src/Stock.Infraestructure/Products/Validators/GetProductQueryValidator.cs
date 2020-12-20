using FluentValidation;
using Stock.Application.Products.Queries;

namespace Stock.Infrastructure.Products.Validators
{
    /// <summary>
    /// Con fluentapi
    /// </summary>
    public class GetProductQueryValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductQueryValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
        }
    }
}
