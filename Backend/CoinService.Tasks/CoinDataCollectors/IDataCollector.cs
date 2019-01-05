namespace CoinService.Tasks.CoinDataCollectors
{
	interface IDataCollector
	{
		/// <summary>
		/// This function will register the data collector.
		/// </summary>
		void Register();

		/// <summary>
		/// With this function the Interval at which the data needs to
		/// be collected is defined. This interval is specified in the Cron format.
		/// </summary>
		string Interval();

		/// <summary>
		/// This task function, is the function where the magic happens. Between those two
		/// parantheses we define what action this task needs to perform.
		/// </summary>
		void Task();
	}
}
