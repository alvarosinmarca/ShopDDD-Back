using System;
using SharedKernel.Application.Cqrs.Queries;

namespace Stock.Application.Products.Queries
{
    // ESTO ES LO QUE SERIA UN RECORD EN .NET 5.0

    /// <summary>
    /// Esto es el contrato con la API (Es un DTO)
    /// </summary>
    public class GetProductQuery : IQueryRequest<Guid> // Esto es lo que retorna (Un dto cuando tenga)
    {
        public GetProductQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

    }
}
