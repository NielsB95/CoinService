using CoinService.DataLayer;
using CoinService.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoinService
{
	public class Startup
	{
		public Startup(IConfiguration configuration, IServiceProvider serviceProvider)
		{
			Configuration = configuration;
			ServiceProvider = serviceProvider;
		}

		public IConfiguration Configuration { get; }
		public IServiceProvider ServiceProvider { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDataLayer();
			services.AddTasks(ServiceProvider, Configuration);

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseTasks();

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
