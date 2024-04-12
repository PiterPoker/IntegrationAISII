using Autofac;
using Autofac.Extensions.DependencyInjection;
using IntegrationAISII.API.Infrastructure.AutofacModules;
using IntegrationAISII.Infrastructure;
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

        public static IServiceProvider AddCustomAutofac(this IServiceCollection services, IConfiguration configuration)
        {
            //configure autofac

            var container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new MediatorModule());
            container.RegisterModule(new ApplicationModule(configuration["ConnectionString"]));

            return new AutofacServiceProvider(container.Build());
        }


    }
}
