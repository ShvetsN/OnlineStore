using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DataLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using DataLayer.Сontexts;
using UnitOfWork.Interfaces;
using UnitOfWork.UnitOfWork;
using BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DataLayer.Identity;
using AutoMapper;
using BusinessLogicLayer.Interfaces;
using UnitOfWork.Repositories;

namespace OnlineStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddDbContext<StoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OnlineStore")));
            services.AddDbContext<UserContext>(options => options.UseSqlServer(Configuration.GetConnectionString("OnlineStoreUsers")));
            services.AddScoped<IIdentityService, IdentityServices>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped(typeof(IRepository<,>), typeof(GenericRepository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWorkPattern>();
            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
            services.AddScoped<IOrderManipulator, OrderManipulator>();
            services.AddScoped<IProductManipulator, ProductManipulator>();

            // ===== Add Identity ========

            services.AddIdentity<User, UserRole>()
                .AddEntityFrameworkStores<UserContext>()
                .AddDefaultTokenProviders();



            // ===== Add Jwt Authentication ========

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims

            services

                .AddAuthentication(options =>

                {

                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;



                })

                .AddJwtBearer(cfg =>

                {

                    cfg.RequireHttpsMetadata = false;

                    cfg.SaveToken = true;

                    cfg.TokenValidationParameters = new TokenValidationParameters

                    {

                        ValidIssuer = Configuration["JwtIssuer"],

                        ValidAudience = Configuration["JwtIssuer"],

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),

                        ClockSkew = TimeSpan.Zero // remove delay of token when expire

                    };

                });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
