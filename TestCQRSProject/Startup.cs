using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TestCQRSProject.Locations.Commands;
using MediatR;
using MediatR.Pipeline;
using System.Reflection;
using TestCQRSProject.Interfaces;
using TestCQRSProject.Services;
using TestCQRSProject.Providers;
using TestCQRSProject.Locations.Models;
using TestCQRSProject.DataAccess;
using TestCQRSProject.Infrastructure;

namespace TestCQRSProject
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Add MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR();
            services.AddMediatR(typeof(CreateLocationCommandHandler).GetTypeInfo().Assembly);

            services.AddSingleton<IDataAccess, LocationDataAccess>();
            services.AddSingleton<ILocationService, LocationService>();
            services.AddSingleton<ILocationProvider, LocationProvider>();

            services.AddTransient<ILocation, Location>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
