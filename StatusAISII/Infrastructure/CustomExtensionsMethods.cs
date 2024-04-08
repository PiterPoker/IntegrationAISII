using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace StatusAISII.Infrastructure
{
    public static class CustomExtensionsMethods
    {

        public static IServiceCollection AddCustomHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddHealthChecksUI()
                .AddInMemoryStorage();

            return services;
        }
    }
}
