using CoinService.Tasks.CoinDataCollectors;
using Hangfire;
using System;

namespace CoinService.Tasks
{
	public class BitcoinDataCollector : IDataCollector
	{
		public void Register()
		{
			RecurringJob.AddOrUpdate(() => this.Task(), this.Interval());
		}

		public string Interval()
		{
			return Cron.MinuteInterval(5);
		}

		public void Task()
		{
			Console.WriteLine("Hello task!");
		}
	}
}
