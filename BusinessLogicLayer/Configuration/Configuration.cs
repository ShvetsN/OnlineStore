using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;

namespace BusinessLogicLayer.Configuration
{
    public class Configuration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
           /* services.AddScoped<IOrderManipulator, OrderManipulator>();
            services.AddScoped<IProductManipulator, ProductManipulator>();*/
        }
    }
}
