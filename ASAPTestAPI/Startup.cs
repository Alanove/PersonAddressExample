using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

using ASAP.Data;
using ASAP.Data.Entities;

namespace ASAPTestAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			_config = configuration;
		}

		public IConfiguration _config { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddEntityFrameworkSqlServer();

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			//Dependency injection for data manager
			services.AddDbContext<DataContext>(options =>
				options.UseSqlServer(_config.GetConnectionString("Default")));
			services.AddScoped<IDataManager, DataManager>();


			services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
					.AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASAP", Version = "v1" });
			});


			services.AddCors(options =>
			{
				options.AddPolicy("AllowAllOrigins",
				 builder =>
				 {
					 builder.AllowAnyMethod()
					 .AllowAnyHeader()
					 .AllowAnyOrigin();
				 });
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostEnvironment  env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				//     app.UseHsts();
			}

			//   app.UseHttpsRedirection();
			app.UseStaticFiles();
			//app.UseSpaStaticFiles();

			//app.UseAuthentication();

			app.UseCors("AllowAllOrigins");


			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
			// specifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASAP");
			});

			app.UseMvcWithDefaultRoute();
		}
	}
}