using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UnitOfWork.Interfaces;
using UnitOfWork.Repositories;
using UnitOfWork.UnitOfWork;

namespace UnitOfWork.Configuration
{
    public class Configuration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWorkPattern>();
            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
            DataLayer.Configuration.Configuration.Configure(services, configuration);
        }
    }
}
