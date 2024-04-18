using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using IntegrationAISII.API.Application.Behaviors;
using IntegrationAISII.Domain.AggregatesModel.DocumentAggregate.DocumentAggregate.IncomingDocumentAggregate;
using IntegrationAISII.Infrastructure;
using IntegrationAISII.Infrastructure.Idempotency;
using IntegrationAISII.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection;

namespace IntegrationAISII.API.Infrastructure
{
    public static class CustomExtensionsMethods
    {

        public static IServiceCollection AddCustomHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetConnectionString("DefaultConnection") is string connectionString)
            {
                var hcBuilder = services.AddHealthChecks();

                hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy())
                    .AddNpgSql(connectionString,
                               name: "AISIIDB-check",
                               tags: new string[] { "aisiidb" });


                /*services
                    .AddHealthChecksUI()
                    .AddInMemoryStorage(); */
            }
            else
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {


            if (configuration.GetConnectionString("DefaultConnection") is string connectionString)
            {
                services.AddEntityFrameworkNpgsql()
                    .AddDbContext<IntegrationAISIIContext>(options =>
                    {
                        options.UseNpgsql(connectionString,
                                             npgsqlOptionsAction: pgSqlOptions =>
                                             {
                                                 pgSqlOptions.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
                                             //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                                             pgSqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                                             });
                    });
            }
            else
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Pooling is disabled because of the following error:
            // Unhandled exception. System.InvalidOperationException:
            if (configuration.GetConnectionString("DefaultConnection") is string connectionString)
            {
                // The DbContext of type 'OrderingContext' cannot be pooled because it does not have a public constructor accepting a single parameter of type DbContextOptions or has more than one constructor.
                services.AddDbContext<IntegrationAISIIContext>(options =>
                {
                    options.UseNpgsql(connectionString);
                });
            }
            else
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            //builder.EnrichNpgsqlDbContext<IntegrationAISIIContext>();

            // Configure mediatR
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining(typeof(Program));

                cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
                cfg.AddOpenBehavior(typeof(ValidatorBehavior<,>));
                cfg.AddOpenBehavior(typeof(TransactionBehavior<,>));
            });

            // Register the command validators for the validator behavior (validators based on FluentValidation library)
            /*services.AddSingleton<IValidator<CancelOrderCommand>, CancelOrderCommandValidator>();
            services.AddSingleton<IValidator<CreateOrderCommand>, CreateOrderCommandValidator>();
            services.AddSingleton<IValidator<IdentifiedCommand<CreateOrderCommand, bool>>, IdentifiedCommandValidator>();
            services.AddSingleton<IValidator<ShipOrderCommand>, ShipOrderCommandValidator>();

            services.AddScoped<IOrderQueries, OrderQueries>();
            services.AddScoped<IBuyerRepository, BuyerRepository>();*/
            services.AddScoped<IIncomingDocumentRepository, IncomingDocumentRepository>();
            services.AddScoped<IRequestManager, RequestManager>();

            return services;
        }
    }
}
