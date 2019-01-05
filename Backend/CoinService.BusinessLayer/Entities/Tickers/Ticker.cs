using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinService.BusinessLayer.Entities.Tickers
{
	public class Ticker : Entity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }

		public string Symbol { get; set; }
		public decimal Bid { get; set; }
		public decimal BidSize { get; set; }
		public decimal Ask { get; set; }
		public decimal AskSize { get; set; }
		public decimal DailyChange { get; set; }
		public decimal DailyChangePerc { get; set; }
		public decimal LastPrice { get; set; }
		public decimal Volume { get; set; }
		public decimal High { get; set; }
		public decimal Low { get; set; }
		public DateTime Timestamp { get; set; }

		public override string ToString()
		{
			return string.Format("{0} - {1} - {2}", Symbol, Bid, Ask);
		}
	}
}
