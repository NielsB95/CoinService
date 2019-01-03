using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

			return app;
		}
	}
}
