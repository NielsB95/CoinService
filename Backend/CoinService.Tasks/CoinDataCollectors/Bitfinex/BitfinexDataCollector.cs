using CoinService.BusinessLayer.Entities.Tickers;
using CoinService.Tasks.Util.cs;
using Hangfire;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace CoinService.Tasks.CoinDataCollectors.Bitfinex
{
	public class BitfinexDataCollector : IDataCollector
	{
		private static readonly Uri BitfinexTickersEndpoint = new Uri("https://api.bitfinex.com/v2/tickers");
		private readonly ITickerRepository tickerRepository;
		private readonly IConfiguration configuration;

		public BitfinexDataCollector(ITickerRepository tickerRepository, IConfiguration configuration)
		{
			this.tickerRepository = tickerRepository;
			this.configuration = configuration;
		}

		public string Interval()
		{
			return Cron.Minutely();
		}

		public void Register()
		{
			RecurringJob.AddOrUpdate(() => this.Task(), this.Interval());
		}

		public async Task Task()
		{
			var symbols = configuration["Symbols"];

			var uri = new Uri(BitfinexTickersEndpoint, string.Format("?symbols={0}", symbols));
			var data = await Requests.GET(uri);
			var tickers = BitfinexTickerParser.Parse(data);
			foreach (var ticker in tickers)
				await tickerRepository.Add(ticker);
		}
	}
}
