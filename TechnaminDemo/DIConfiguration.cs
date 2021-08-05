using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TechnaminDemo
{
    internal static class DIConfiguration
    {
        public static void ConfigureDI(this IServiceCollection services, IConfiguration configuration)
        {
            BLL.DIConfiguration.ConfigureDI(services, configuration);

            services.AddScoped<ServiceFactory>();
        }
    }
}
