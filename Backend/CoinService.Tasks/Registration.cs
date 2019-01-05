﻿using CoinService.Tasks.CoinDataCollectors;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CoinService.Tasks
{
	public static class Registration
	{
		public static IServiceCollection AddTasks(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddHangfire(config => config.UsePostgreSqlStorage(configuration.GetConnectionString("CoinDB")));

			return services;
		}

		public static IApplicationBuilder UseTasks(this IApplicationBuilder app)
		{
			app.UseHangfireServer();
			app.UseHangfireDashboard();

			// Register the Hangfire tasks
			RegisterTasks();

			return app;
		}

		private static void RegisterTasks()
		{
			// Get the classes that implement the IDataCollector interface.
			var collectorTaskTypes = typeof(IDataCollector).Assembly.GetTypes()
				.Where(x => typeof(IDataCollector).IsAssignableFrom(x))
				.Where(x => x.IsClass)
				.ToList();

			foreach (var taskType in collectorTaskTypes)
			{
				var task = Activator.CreateInstance(taskType) as IDataCollector;
				task.Register();
			}
		}
	}
}
