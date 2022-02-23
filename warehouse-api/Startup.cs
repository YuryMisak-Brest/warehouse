using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WarehouseApi.Service;
using WarehouseApi.Service.Interface;
using WarehouseApi.Storage;
using WarehouseApi.Storage.Interfaces;

namespace WarehouseApi
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
			services.AddControllers();
			services.AddTransient<IVehiclesService, VehiclesService>();
			services.AddTransient<IVehiclesRepository, VehiclesRepository>();
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new WarehouseProfile());
			});

			IMapper mapper = mappingConfig.CreateMapper();
			services.AddSingleton(mapper);

			services.AddMvc();
			var optionsBuilder = new DbContextOptionsBuilder();
			services.AddDbContext<WarehouseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("WarehouseDatabase")));

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
			
			app.UseCors(x => x
				.AllowAnyMethod()
				.AllowAnyHeader()
				.SetIsOriginAllowed(origin => true) // allow any origin
				.AllowCredentials()); // allow credentials

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<WarehouseContext>();
				if (context.Database.EnsureCreated())
				{
					var vehiclesService = serviceScope.ServiceProvider.GetRequiredService<IVehiclesService>();
					vehiclesService.InitializeVehicles();
				}
			}
		}
	}
}
