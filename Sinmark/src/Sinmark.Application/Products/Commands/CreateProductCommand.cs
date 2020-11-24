using System;
using SharedKernel.Application.Cqrs.Commands;

namespace Sinmark.Application.Products.Commands
{
    // ESTO ES LO QUE SERIA UN RECORD EN .NET 5.0

    /// <summary>
    /// Esto es el contrato con la API (Es un DTO)
    /// </summary>
    public class CreateProductCommand : ICommandRequest
    {
        public CreateProductCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

    }
}
