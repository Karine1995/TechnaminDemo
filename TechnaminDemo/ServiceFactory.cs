using System;
using BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace TechnaminDemo
{
    /// <summary>
    /// Get BLL services
    /// </summary>
    public class ServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// </summary>
        /// <param name="serviceProvider"></param>
        public ServiceFactory(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        /// <summary>
        /// Project service
        /// </summary>
        public IProductService ProductService => _serviceProvider.GetService<IProductService>();
    }
}
