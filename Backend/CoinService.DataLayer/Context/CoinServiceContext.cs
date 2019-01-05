using CoinService.BusinessLayer.Entities.Tickers;
using Microsoft.EntityFrameworkCore;

namespace CoinService.DataLayer.Context
{
	public class CoinServiceContext : DbContext
	{
		public CoinServiceContext()
		{
		}

		public CoinServiceContext(DbContextOptions<CoinServiceContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// Only configure if it hasn't been configured yet. We are probably
			// running unit tests if it hasn't been configured.
			if (!optionsBuilder.IsConfigured)
				base.OnConfiguring(optionsBuilder);
		}

		public DbSet<Ticker> Tickers { get; set; }
	}
}
