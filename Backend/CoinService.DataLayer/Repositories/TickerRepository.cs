using CoinService.BusinessLayer.Entities.Tickers;
using CoinService.DataLayer.Context;

namespace CoinService.DataLayer.Repositories
{
	public class TickerRepository : Repository<Ticker>, ITickerRepository
	{
		public TickerRepository(CoinServiceContext context) : base(context)
		{
		}
	}
}
