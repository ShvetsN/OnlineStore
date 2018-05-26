using DataLayer.Contexts;
using DataLayer.Identity;
using DataLayer.Сontexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configuration
{
    public class Configuration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(options => options.UseSqlServer(configuration.GetConnectionString("OnlineStore")));
            services.AddDbContext<UserContext>(options => options.UseSqlServer(configuration.GetConnectionString("OnlineStoreUsers")));
            services.AddScoped<IUserDbInitializer, UserDbInitializer>();

            services.AddIdentity<User, UserRole>()
                .AddEntityFrameworkStores<UserContext>()
                .AddDefaultTokenProviders();

            var scope = services.BuildServiceProvider();
            var initializer = scope.GetService<IUserDbInitializer>();
            initializer.Seed().Wait();

        }
    }
}
