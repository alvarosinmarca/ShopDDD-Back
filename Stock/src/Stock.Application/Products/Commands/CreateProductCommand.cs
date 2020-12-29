using SharedKernel.Application.Cqrs.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stock.Application.Products.Commands
{
    public class CreateProductCommand : ICommandRequest
    {
        public CreateProductCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
