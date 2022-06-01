using FluentValidation.AspNetCore;
using MGK.ServiceBase.Infrastructure.Extensions;
using BSoft.BinanceGraph.API.Infrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using BSoft.BApp.Core.Base;

namespace BSoft.BinanceGraph.API
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
			services.AddMvc()
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

			// Configure the services declared in the assembly
			BaseServiceRegistration.RegisterAllServicers(services, _configuration);
			
			//Services.AddServices(_configuration);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHsts();
			app.UseHttpsRedirection();
			app.UseRouting();
			//app.UseAuthentication();
			app.UseAuthorization();

			if (!env.IsProduction())
			{
				app.UseDevMiddleware();
			}

			// Configure application features
			app.AddAppConfigurations(_configuration);

			app.UseEndpoints(ep =>
				ep.MapControllers());
				//.RequireAuthorization());
		}
	}
}
