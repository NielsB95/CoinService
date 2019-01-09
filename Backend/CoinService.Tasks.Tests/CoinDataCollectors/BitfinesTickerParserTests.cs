using CoinService.Tasks.CoinDataCollectors.Bitfinex;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CoinService.Tasks.Tests.CoinDataCollectors
{
	[TestClass]
	public class BitfinesTickerParserTests
	{
		[TestMethod]
		public void ParseToArraysOfDataTest()
		{
			var data = "['\"tBTCUSD\",3960,53.44040222,3960.2,40.88483626,55.1,0.0141,3960.1,13464.22326092,4014.9,3850.1]";
			var ticker = BitfinexTickerParser.ParseProperties(data);

			Assert.AreEqual("tBTCUSD", ticker.Symbol);
			Assert.AreEqual(3960m, ticker.Bid);
			Assert.AreEqual(53.44040222m, ticker.BidSize);
			Assert.AreEqual(3960.2m, ticker.Ask);
			Assert.AreEqual(40.88483626m, ticker.AskSize);
			Assert.AreEqual(55.1m, ticker.DailyChange);
			Assert.AreEqual(0.0141m, ticker.DailyChangePerc);
			Assert.AreEqual(3960.1m, ticker.LastPrice);
			Assert.AreEqual(13464.22326092m, ticker.Volume);
			Assert.AreEqual(4014.9m, ticker.High);
			Assert.AreEqual(3850.1m, ticker.Low);
		}

		[TestMethod]
		public void ParseToArraysOfData2Test()
		{
			var data = "[['\"tBTCUSD\",3960,53.44040222,3960.2,40.88483626,55.1,0.0141,3960.1,13464.22326092,4014.9,3850.1], ['\"tBTCUSD\",3960,53.44040222,3960.2,40.88483626,55.1,0.0141,3960.1,13464.22326092,4014.9,3850.1]]";
			var result = BitfinexTickerParser.Parse(data)
				.ToList();

			Assert.AreEqual(2, result.Count);
		}
	}
}
