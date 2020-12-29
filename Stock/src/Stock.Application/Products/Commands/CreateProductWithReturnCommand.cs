using System;
using SharedKernel.Application.Cqrs.Commands;

namespace Stock.Application.Products.Commands
{
    /// <summary>
    /// This is a contract with the API, similar to Dto, this can be write with new feature RECORD
    /// </summary>
    public class CreateProductWithReturnCommand : ICommandRequest<Guid>
    {
        public CreateProductWithReturnCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

    }
}
