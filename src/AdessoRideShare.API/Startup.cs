using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdessoRideShare.Application.Helpers;
using AdessoRideShare.Application.Helpers.Interfaces;
using AdessoRideShare.Application.Interfaces;
using AdessoRideShare.Application.Services;
using AdessoRideShare.Core.Data;
using AdessoRideShare.Core.Repositories;
using AdessoRideShare.Infrastructure.Data;
using AdessoRideShare.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

namespace AdessoRideShare.API
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

            #region Redis Dependencies

            //create ConnectionMultiplexer object given parameters
            services.AddSingleton<ConnectionMultiplexer>(sp =>
            {
                var configuraitonParameters = ConfigurationOptions.Parse(Configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(configuraitonParameters);
            });

            #endregion

            #region Project Dependencies

            services.AddScoped<IRideDbContext, RideDbContext>();
            services.AddScoped<IRideService, RideService>();
            services.AddScoped<IRotaService, RotaService>();
            services.AddScoped<ICityParser, CityParser>();
            services.AddScoped<IRideRepository, RideRepository>();
            //services.AddTransient<IValidator<BasketItemModel>, BasketItemModelValidator>();

            services.AddAutoMapper(typeof(Startup));

            #endregion

            #region Swagger Dependencies

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Basket API", Version = "v1" });
            });

            #endregion

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basket API V1");
            });
        }
    }
}
