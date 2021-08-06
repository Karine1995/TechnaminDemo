using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using Common;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class DIConfiguration
    {
        public static void ConfigureDI(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(Constants.TechnaminDemoDb);

            services.AddDbContext<TechnaminDemoDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            //services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IService, Service>();
        }
    }
}
