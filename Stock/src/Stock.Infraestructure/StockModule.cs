using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Infrastructure.Cqrs.Commands;
using SharedKernel.Infrastructure.Cqrs.Queries;
using SharedKernel.Infrastructure.Data.Dapper;
using SharedKernel.Infrastructure.Data.EntityFrameworkCore;
using SharedKernel.Infrastructure.Events;
using Stock.Application.Products.Commands;
using Stock.Application.Products.Create;
using Stock.Application.Products.Subscribers;
using Stock.Domain.Products;
using Stock.Domain.Products.Events;
using Stock.Infrastructure.Data.EFCore;
using Stock.Infrastructure.Products;

namespace Stock.Infrastructure
{
    /// <summary>
    /// Registramos las dependencias de este módulo
    /// </summary>
    public static class StockModule
    {
        public static IServiceCollection AddStockModule(this IServiceCollection services,
        IConfiguration configuration, string connectionStringName)
        {
            return services
                .AddDomainEvents(typeof(ProductCreatedDomainEvent)) // Esta es una clase, pero puede ser cualquiera de la misma capa
                .AddDomainEventsSubscribers(typeof(SendMailProductCreatedDomainEventSubscriber)) // Esta es una clase, pero puede ser cualquiera de la misma capa
                .AddCommandsHandlers(typeof(CreateProductCommandHandler)) // Esta es una clase, pero puede ser cualquiera de la misma capa
                .AddQueriesHandlers(typeof(StockDbContext))
                .AddDapperSqlServer<StockDbContext>(configuration, connectionStringName)
                .AddEntityFrameworkCoreSqlServer<StockDbContext>(configuration, connectionStringName)
                .AddApplicationServices()
                .AddDomainServices()
                .AddRepositories();
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ProductCreator, ProductCreator>();
            services.AddScoped<SendMailProductCreatedDomainEventSubscriber, SendMailProductCreatedDomainEventSubscriber>();
            return services;
        }

        private static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddTransient<IProductRepository, ProductEntityFrameworkCoreRepository>();
        }
    }
}
