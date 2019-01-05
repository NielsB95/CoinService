using CoinService.BusinessLayer.Entities.Tickers;
using CoinService.Tasks.CoinDataCollectors.Bitfinex;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoinService.Tasks
{
	public static class Registration
	{
		private static IConfiguration configuration;
		private static IServiceProvider serviceProvider;


		public static IServiceCollection AddTasks(this IServiceCollection services, IServiceProvider serviceProvider, IConfiguration configuration)
		{
			Registration.configuration = configuration;
			Registration.serviceProvider = serviceProvider;

			services.AddHangfire(config => config.UsePostgreSqlStorage(configuration.GetConnectionString("CoinDB")));

			return services;
		}

		public static IApplicationBuilder UseTasks(this IApplicationBuilder app)
		{
			app.UseHangfireServer();
			app.UseHangfireDashboard();

			app.RegisterTasks();

			return app;
		}

		private static IApplicationBuilder RegisterTasks(this IApplicationBuilder app)
		{
			var tickerRepository = serviceProvider.GetService<ITickerRepository>();
			new BitfinexDataCollector(tickerRepository, configuration).Register();

			return app;
		}
	}
}
