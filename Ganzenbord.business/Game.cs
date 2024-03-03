using System;

namespace Ganzenbord.Business
{
	public class Game
	{
		public List<Player> Players;
		public Board Board { get; set; }
		public bool End { get; private set; }
		public int Turn { get; set; } = 1;
		private Random random;

		public Game(int amountOfPlayers)
		{
			Board = Board.Instance;
			random = new Random();
			Players = new List<Player>();

			for (int i = 0; i < amountOfPlayers; i++)
			{
				Players.Add(new Player());
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
		public void PlayRound(int[]? diceRolls = null)
		{
			if (!End)
			{
				diceRolls = checkIfTestDataIsNull(diceRolls);

				if (Turn == 1)
				{
					HandleFirstTurnEdgeCase(diceRolls);
				}
				else
				{
					HandleStandardTurn(diceRolls);
				}

				Turn++;
			}
		}

		private void HandleStandardTurn(int[] diceRolls)
		{
			foreach (Player player in Players)
			{
				player.PlayTurn(diceRolls);
				if (player.Winner)
				{
					End = true;
					break;
				}
			}
		}

		private void HandleFirstTurnEdgeCase(int[] diceRolls)
		{
			foreach (Player player in Players)
			{
				diceRolls = checkIfTestDataIsNull(diceRolls);

				if (diceRolls.Contains(6) && diceRolls.Contains(3))
				{
					player.MoveToPosition(53);
				}
				else if (diceRolls.Contains(5) && diceRolls.Contains(4))
				{
					player.MoveToPosition(26);
				}
				else
				{
					player.PlayTurn(diceRolls);
				}
			}
		}

		private int[] checkIfTestDataIsNull(int[]? diceRolls)
		{
			if (diceRolls == null)
			{
				diceRolls = RollDice();
			}

			return diceRolls;
		}

		public int[] RollDice(int amountOfDice = 2)
		{
			int[] rolls = new int[amountOfDice];

			for (int i = 0; i < amountOfDice; i++)
			{
				rolls[i] = random.Next(1, 7);
			}

			return rolls;
		}
	}
}