using CoinService.BusinessLayer.Entities.Tickers;
using Hangfire;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace CoinService.Tasks.CoinDataCollectors.Bitcoin
{
	public class BitcoinDataCollector : IDataCollector
	{
		private static readonly Uri BitfinexTickersEndpoint = new Uri("https://api.bitfinex.com/v2/tickers");
		private readonly ITickerRepository tickerRepository;

		public BitcoinDataCollector(ITickerRepository tickerRepository)
		{
			this.tickerRepository = tickerRepository;

			RecurringJob.AddOrUpdate(() => this.Task(), this.Interval());
		}

		public string Interval()
		{
			return Cron.Minutely();
		}

		public async Task Task()
		{
			var uri = new Uri(BitfinexTickersEndpoint, "?symbols=tBTCUSD,tLTCUSD");

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
			request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

			using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
			using (Stream stream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(stream))
			{
				var data = await reader.ReadToEndAsync();
				var tickers = BitfinexTickerParser.Parse(data);
				foreach (var ticker in tickers)
				{
					await tickerRepository.Add(ticker);
					Console.WriteLine("Added a ticker for {0}", ticker.Symbol);
				}
			}
		}
	}
}
