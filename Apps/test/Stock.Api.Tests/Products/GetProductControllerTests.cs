using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SharedKernel.Application.Cqrs.Queries;
using Stock.Api.Products;
using Xunit;

namespace Stock.Api.Tests.Products
{
    public class GetProductControllerTests
    {
        private readonly IQueryBus _queryBus;

        public GetProductControllerTests(IQueryBus queryBus)
        {
            _queryBus = queryBus;
        }

        [Fact]
        public async Task GetProductById()
        {

        }

        [Fact]
        public async Task GetProductByWrongId()
        {
            var newProductId = Guid.NewGuid();
            
            var response = await new ProductsController().GetProduct(_queryBus, newProductId, It.IsAny<CancellationToken>());

            Assert.True(response.Value.ToString() == "00000000-0000-0000-0000-000000000000");
        }
    }
}
