using DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnaminDemo.Services
{
    public static class DependencyInjection
    {
        public static void TypesInject(this IServiceCollection services)
        {
            services.AddScoped<IProductOperations, ProductOperations>();
            //services.AddScoped<IProductBL, ProductBL>();
        }
    }
}
