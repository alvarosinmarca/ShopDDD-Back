using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Infrastructure.Cqrs.Commands;
using SharedKernel.Infrastructure.Cqrs.Queries;
using SharedKernel.Infrastructure.Data.Dapper.Queries;
using SharedKernel.Infrastructure.Data.EntityFrameworkCore.DbContexts;
using SharedKernel.Infrastructure.Data.EntityFrameworkCore.Queries;
using SharedKernel.Infrastructure.Events;
using Stock.Application.Products.Commands;
using Stock.Domain.Products;
using Stock.Infraestructure.Data.EFCore;
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
            // TODO AUTOMAPPER

            //var assemblies = new[]
            //{ // Ponemos 3 tipos de cada ensamblado para hacer magia
            //typeof(CreateProductCommand).Assembly,
            //typeof(Product).Assembly,
            //typeof(StockDbContext).Assembly
            //};

            //services.Configure<Sermepa>(configuration.GetSection(nameof(Sermepa)));

            return services
           //.AddAutoMapper(assemblies)
           .AddDomainEventsSubscribers(typeof(CreateProductCommand).Assembly) // Esta es una clase, pero puede ser cualquiera de la misma capa
           .AddCommandsHandlers(typeof(CreateProductCommand).Assembly)
           .AddQueriesHandlers(typeof(StockDbContext).Assembly)
           .AddPaymentSqlServerPersitence(configuration, connectionStringName);
        }

        private static IServiceCollection AddPaymentSqlServerPersitence(this IServiceCollection services,
       IConfiguration configuration, string connectionStringName)
        {
            services.AddScoped(s =>
            new DbContextOptionsBuilder<StockDbContext>()
            .UseSqlServer(configuration.GetConnectionString(connectionStringName))
            .EnableSensitiveDataLogging());

            // Escritura
            services.AddDbContext<StockDbContext>(s =>
            s.UseSqlServer(configuration.GetConnectionString(connectionStringName))
            .EnableSensitiveDataLogging(), ServiceLifetime.Transient);

            //services.AddScoped<IPaymentUnitOfWork, StockDbContext>();

            // Lectura
            services.AddScoped(s =>
            new EntityFrameworkCoreQueryProvider<StockDbContext>(() => new StockDbContext(
            s.GetRequiredService<DbContextOptionsBuilder<StockDbContext>>()
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).Options,
            s.GetService<IAuditableService>())));

            services.AddScoped(s =>
           new DapperQueryProvider<StockDbContext>(() => new StockDbContext(
           s.GetRequiredService<DbContextOptionsBuilder<StockDbContext>>()
           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).Options,
           s.GetService<IAuditableService>())));

            return services
                .AddTransient<IProductRepository, ProductEntityFrameworkCoreRepository>();
            //.AddTransient<IPaymentMadeRepository, PaymentMadeEntityFrameworkCoreRepository>()
            //.AddTransient<IPaymentService, PaymentService>();
        }
    }
}
