using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Infrastructure.Cqrs.Commands;
using SharedKernel.Infrastructure.Cqrs.Queries;
using SharedKernel.Infrastructure.Data.Dapper.Queries;
using SharedKernel.Infrastructure.Data.EntityFrameworkCore.DbContexts;
using SharedKernel.Infrastructure.Data.EntityFrameworkCore.Queries;
using SharedKernel.Infrastructure.Events;
using Sinmark.Application.Products.Commands;
using Sinmark.Domain.Products;
using Sinmark.Infraestructure.Data.EFCore;
using Sinmark.Infrastructure.Products;

namespace Sinmark.Infrastructure
{
    /// <summary>
    /// Registramos las dependencias de este módulo
    /// </summary>
    public static class SinmarkModule
    {
        public static IServiceCollection AddSinmarkModule(this IServiceCollection services,
        IConfiguration configuration, string connectionStringName)
        {
            // TODO AUTOMAPPER

            //var assemblies = new[]
            //{ // Ponemos 3 tipos de cada ensamblado para hacer magia
            //typeof(CreateProductCommand).Assembly,
            //typeof(Product).Assembly,
            //typeof(SinmarkDbContext).Assembly
            //};

            //services.Configure<Sermepa>(configuration.GetSection(nameof(Sermepa)));

            return services
           //.AddAutoMapper(assemblies)
           .AddDomainEventsSubscribers(typeof(CreateProductCommand).Assembly) // Esta es una clase, pero puede ser cualquiera de la misma capa
           .AddCommandsHandlers(typeof(CreateProductCommand).Assembly)
           .AddQueriesHandlers(typeof(SinmarkDbContext).Assembly)
           .AddPaymentSqlServerPersitence(configuration, connectionStringName);
        }

        private static IServiceCollection AddPaymentSqlServerPersitence(this IServiceCollection services,
       IConfiguration configuration, string connectionStringName)
        {
            services.AddScoped(s =>
            new DbContextOptionsBuilder<SinmarkDbContext>()
            .UseSqlServer(configuration.GetConnectionString(connectionStringName))
            .EnableSensitiveDataLogging());

            // Escritura
            services.AddDbContext<SinmarkDbContext>(s =>
            s.UseSqlServer(configuration.GetConnectionString(connectionStringName))
            .EnableSensitiveDataLogging(), ServiceLifetime.Transient);

            //services.AddScoped<IPaymentUnitOfWork, SinmarkDbContext>();

            // Lectura
            services.AddScoped(s =>
            new EntityFrameworkCoreQueryProvider<SinmarkDbContext>(() => new SinmarkDbContext(
            s.GetRequiredService<DbContextOptionsBuilder<SinmarkDbContext>>()
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).Options,
            s.GetService<IAuditableService>())));

            services.AddScoped(s =>
           new DapperQueryProvider<SinmarkDbContext>(() => new SinmarkDbContext(
           s.GetRequiredService<DbContextOptionsBuilder<SinmarkDbContext>>()
           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).Options,
           s.GetService<IAuditableService>())));

            return services
                .AddTransient<IProductRepository, ProductEntityFrameworkCoreRepository>();
            //.AddTransient<IPaymentMadeRepository, PaymentMadeEntityFrameworkCoreRepository>()
            //.AddTransient<IPaymentService, PaymentService>();
        }
    }
}
