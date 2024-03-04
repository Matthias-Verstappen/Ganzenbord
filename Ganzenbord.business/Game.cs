using Ganzenbord.Business.Factories;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Services;

namespace Ganzenbord.Business
{
	public class Game
	{
		public List<Player> Players;

		private ILogger _logger;
		private IPlayerFactory _playerFactory;

		public Board Board { get; set; }

		public bool End { get; private set; }

		public int Turn { get; set; } = 1;

		public bool IsFirstTurn
		{ get { return Turn == 1; } }

		private Random random;

		public Game(ILogger logger, IPlayerFactory playerFactory, int amountOfPlayers)
		{
			Board = Board.Instance;
			random = new Random();
			Players = new List<Player>();
			_logger = logger;

			for (int i = 0; i < amountOfPlayers; i++)
			{
				Player player = playerFactory.CreatePlayer();
				player.PlayerNumber = i + 1;
				Players.Add(player);
			}
		}

		public void SetTurnTo1()
		{
			Turn = 1;
		}

		/// <summary>
		/// This is a fun method
		/// </summary>
		/// <param name="diceRolls">This value should be used for unit testing ONLY</param>
		public void PlayRound()
		{
			if (!End)
			{
				_logger.Log($"\nRound {Turn}");

				foreach (Player player in Players)
				{
					player.RollDice(2, IsFirstTurn);

					if (player.Winner)
					{
						End = true;
						break;
					}
				}

				EndTurn();
			}
		}

		private void EndTurn()
		{
			Turn++;
		}

		public void Start()
		{
			while (!End)
			{
				PlayRound();
			}
		}
	}
}