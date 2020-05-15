using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TruckProject.Entities;
using TruckProject.Services;

namespace TruckProject
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
            var AllowedOrigins = Configuration.GetValue<string>("AllowedOrigins")?.Split(",") ?? new string[0];

            services.AddCors(options => options.AddPolicy("TruckToRia",
                             builer => builer.WithOrigins(AllowedOrigins)
                                             .AllowAnyMethod()
                                             .WithHeaders("Content-Type")
                                             .AllowCredentials()
                                             .SetPreflightMaxAge(TimeSpan.FromMinutes(1))));

            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;

            });
            services.AddDbContext<AutomobileContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TruckDB"));
                    //"Name=TruckDB");
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ITruckLogicRepository, TruckLogicRepository>();
            services.AddMvc(option =>option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("TruckToRia");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
