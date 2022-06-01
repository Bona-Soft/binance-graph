// Copyright (c) BonaSoft, Inc. All rights reserved.

using BSoft.BApp.Core.Extensions;
using BSoft.BApp.Core.Infraestructure;
using BSoft.DemoApp.API.Infrastructure.Extensions;
using FluentValidation.AspNetCore;
using MGK.ServiceBase.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace BSoft.DemoApp.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddNewtonsoftJson(options =>
                {
                    // Use the default property (Pascal) casing
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                })
                .AddControllersAsServices()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });

            services.AddLocalization();
            services.AddHttpContextAccessor();
            services.AddControllers();

            services.RegisterBaseCommonControllerService(_configuration);
            services.RegisterAllServiceRegistrations(_configuration, "BSoft");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseLogMiddleware();
            app.AddAppConfigurations(_configuration);
            app.UseHsts();
            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            
            if (env.IsDevelopment() || env.IsLocal())
            {
                app.UseExceptionHandler("/" + BaseEnviroments.Development.ErrorPath);
            }
            else
            {
                app.UseExceptionHandler("/" + BaseEnviroments.Production.ErrorPath);
            }

            app.UseRouting();
            //app.UseCors();
            //app.UseAuthentication();
            app.UseAuthorization();

            if (!env.IsProduction())
            {
                app.UseDevMiddleware();
            }

            app.UseEndpoints(ep =>
                ep.MapControllers());
            //.RequireAuthorization());
        }
    }
}
