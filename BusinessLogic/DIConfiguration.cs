
using BLL.Interfaces;
using BLL.Services;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class DIConfiguration
    {
        public static void ConfigureDI(IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Data Source =.; Initial Catalog = Products; Integrated Security = True");

            services.AddDbContext<TechnaminDemoDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            //services
            services.AddScoped<IProductService, ProductService>();
            
        }
    }
}
