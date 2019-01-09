using CoinService.BusinessLayer.Entities.Tickers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CoinService.Tasks.CoinDataCollectors.Bitfinex
{
	public static class BitfinexTickerParser
	{
		/// <summary>
		/// This function will parse data that comes from the Bitfinex endpoints.
		/// </summary>
		/// <param name="bitfinexData"></param>
		/// <returns></returns>
		public static IEnumerable<Ticker> Parse(string bitfinexData)
		{
			// Remove the first and last char; `[` and `]`.
			bitfinexData = bitfinexData.Substring(1, bitfinexData.Length - 2);

			// Convert the string of ticker data to an array.
			var dataArrays = bitfinexData.Split("],").Select(x => x.Trim());
			foreach (var data in dataArrays)
				yield return ParseProperties(data);
		}

		public static Ticker ParseProperties(string tickerData)
		{
			// Remove the first and last char; `[` and `]`.
			tickerData = tickerData.Substring(1, tickerData.Length - 2);

			// Convert the string of data to an array of properties.
			var properties = tickerData.Split(',')
				.Select(x => x.Trim())
				.ToList();

			return new Ticker()
			{
				// Remove the qutoes around the Symbol.
				Symbol = SanitzeSymbol(properties[0]),
				Bid = ParseBitfinexFloat(properties[1]),
				BidSize = ParseBitfinexFloat(properties[2]),
				Ask = ParseBitfinexFloat(properties[3]),
				AskSize = ParseBitfinexFloat(properties[4]),
				DailyChange = ParseBitfinexFloat(properties[5]),
				DailyChangePerc = ParseBitfinexFloat(properties[6]),
				LastPrice = ParseBitfinexFloat(properties[7]),
				Volume = ParseBitfinexFloat(properties[8]),
				High = ParseBitfinexFloat(properties[9]),
				Low = ParseBitfinexFloat(properties[10]),
				Timestamp = DateTime.UtcNow
			};
		}

		private static string SanitzeSymbol(string symbol)
		{
			// Remove the quotes
			symbol = symbol.Replace("\"", "");

			// Remove single quotes
			symbol = symbol.Replace("\'", "");

			// Remove the backslash
			symbol = symbol.Replace("\\", "");

			return symbol;
		}

		public static decimal ParseBitfinexFloat(string floatValue)
		{
			return decimal.Parse(floatValue, CultureInfo.InvariantCulture);
		}
	}
}
