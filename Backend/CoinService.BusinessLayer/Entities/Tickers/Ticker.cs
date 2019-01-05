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
		public float Bid { get; set; }
		public float BidSize { get; set; }
		public float Ask { get; set; }
		public float AskSize { get; set; }
		public float DailyChange { get; set; }
		public float DailyChangePerc { get; set; }
		public float LastPrice { get; set; }
		public float Volume { get; set; }
		public float High { get; set; }
		public float Low { get; set; }
	}
}
