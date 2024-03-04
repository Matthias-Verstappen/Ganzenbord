using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Services;

namespace Ganzenbord.Business.Factories
{
	public class PlayerFactory : IPlayerFactory
	{
		private ILogger logger;
		private IDiceService diceService;

		public PlayerFactory(ILogger logger, IDiceService diceService)
		{
			this.logger = logger;
			this.diceService = diceService;
		}

		public Player CreatePlayer()
		{
			return new Player(logger, diceService);
		}
	}
}