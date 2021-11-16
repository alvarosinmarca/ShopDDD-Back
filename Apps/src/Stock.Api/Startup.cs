using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SharedKernel.Api.ServiceCollectionExtensions;
using SharedKernel.Api.ServiceCollectionExtensions.OpenApi;
using SharedKernel.Application.Security;
using SharedKernel.Infrastructure;
using SharedKernel.Infrastructure.Caching;
using SharedKernel.Infrastructure.Communication.Email.Smtp;
using SharedKernel.Infrastructure.Cqrs.Commands;
using SharedKernel.Infrastructure.Cqrs.Queries;
using SharedKernel.Infrastructure.Events;
using SharedKernel.Infrastructure.HealthChecks;
using Stock.Infrastructure;
using Stock.Infrastructure.Products.Validators;

namespace Stock.Api
{
    public class Startup
    {
        #region Comentado

        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        //// This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services
        //        .AddSharedKernelApi<ProductValidators>(Configuration)
        //        .AddStockModule(Configuration,"nombreCadenaDeConexion")
        //        .AddDomainEventSubscribersInformation();

        //}

        //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<OpenApiOptions> options)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.UseHttpsRedirection();

        //    app.UseRouting();

        //    app.UseAuthorization();

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapControllers();
        //    });

        //    app.UseOpenApi(options);
        //}

        #endregion

        private const string CorsPolicy = "CorsPolicy";

        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Singleton: Crea una única instancia de toda la aplicación. Crea la instancia por primera vez y reutiliza el mismo objeto en todas las llamadas.
        // Scope: Los servicios se crean una vez por solicitud dentro del alcance. Es equivalente a Singleton en el alcance actual. p.ej.en MVC crea 1 instancia por cada solicitud http pero usa la misma instancia en las otras llamadas dentro de la misma solicitud web.
        // Transient: Los servicios se crean cada vez que se solicitan (Para servicios livianos y apátridas).

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSharedKernel()
                .AddSharedKernelApi<GetProductQueryValidator>(CorsPolicy,
                    Configuration.GetSection("Origins").Get<string[]>())
                .AddSharedKernelHealthChecks()
                .AddSharedKernelOpenApi(Configuration)

                // CACHÉ
                //.AddRedisDistributedCache(Configuration)
                .AddInMemoryCache()

                // COMMAND BUS
                .AddInMemoryCommandBus()

                // QUERY BUS
                .AddInMemoryQueryBus()

                // EVENT BUS
                //.AddRabbitMqEventBus(Configuration)
                //.AddInMemoryEventBus(Configuration)
                .AddRedisEventBus(Configuration)

                // MODULES
                .AddStockModule(Configuration, "StockConnectionPostgreSql")

                // Register all domain event subscribers
                .AddDomainEventSubscribers()
                .AddSmtp(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<OpenApiOptions> options, IOptions<OpenIdOptions> openIdOptions)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(CorsPolicy);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapHealthChecks("/health", new HealthCheckOptions
                    {
                        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                    });

                    endpoints.MapControllers();
                })
                .UseSharedKernelMetrics()
                .UseSharedKernelOpenApi(options, openIdOptions);
        }
    }
}
