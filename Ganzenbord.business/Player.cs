using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Services;
using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business
{
	public class Player(ILogger logger, IDiceService diceService)
	{
		private readonly ILogger _logger = logger;
		private readonly IDiceService _diceService = diceService;

		//public PlayerColor PlayerColor { get; private set; }
		public int Position { get; private set; } = 0;

		public bool CanMove { get; private set; } = true;

		public int TurnsToSkip { get; private set; } = 0;

		public bool Winner { get; private set; } = false;

		public bool ReverseMovement { get; set; } = false;

		public int[] DiceRolls { get; private set; }

		private int boardSize = Board.Instance.Squares.Count - 1;
		public int PlayerNumber { get; set; }

		public void RollDice(int amountOfDice = 2, bool isFirstThrow = false)
		{
			int[] diceRoll = _diceService.RollDice(amountOfDice);
			if (isFirstThrow)
			{
				HandleFirstTurnEdgeCase(diceRoll);
			}
			else
			{
				Move(diceRoll);
			}
		}

		public void Move(int[] diceRolls)
		{
			DiceRolls = diceRolls;
			StandardMove(diceRolls);
			HandlePlayerEnterSquare(Position);
		}

		private void StandardMove(int[] diceRolls)
		{
			int newPosition = Position + diceRolls.Sum();

			if (!ReverseMovement)
			{
				if (newPosition <= boardSize)
				{
					Position = newPosition;
					_logger.Log($"Player's new position: {Position}");
				}
				else
				{
					ReverseMovement = true;
					Position = boardSize - (newPosition - boardSize);
					_logger.Log($"Player {PlayerNumber} is going backwards!");
					_logger.Log($"Player {PlayerNumber}'s new position: {Position}");
				}
			}
			else
			{
				Position -= diceRolls.Sum();
				if (Position < 0)
				{
					Position = 0;
				}
				_logger.Log($"Player {PlayerNumber} is going backwards!");
				_logger.Log($"Player {PlayerNumber}'s new position: {Position}");
			}
		}

		public void MoveToPosition(int position)
		{
			Position = position;

			HandlePlayerEnterSquare(position);
		}

		private void HandlePlayerEnterSquare(int position)
		{
			ISquare square = Board.Instance.Squares[position];
			_logger.Log($"Player {PlayerNumber} entered: {square.GetType().Name}");
			if (square.GetType().Name == "End")
			{
				_logger.Log($"Player {PlayerNumber} won the game!");
			}
			square.PlayerEntersSquare(this);
		}

		public void SetCanMove(bool canMove)
		{
			CanMove = canMove;
		}

		public void SetTurnsToSkip(int amountTurns)
		{
			TurnsToSkip = amountTurns;
			_logger.Log($"Player {PlayerNumber} has to skip {TurnsToSkip} turns!");
		}

		public void PlayTurn(int[] diceRolls)
		{
			//TODO
			if (CanMove)
			{
				DiceRolls = diceRolls;
				_logger.Log($"Player {PlayerNumber} rolls {string.Join(", ", diceRolls)}");
				Move(diceRolls);
				ReverseMovement = false;
			}
			else if (TurnsToSkip > 0)
			{
				TurnsToSkip--;
				if (TurnsToSkip > 0)
				{
					_logger.Log($"Player {PlayerNumber} still has to skip {TurnsToSkip} turns!");
				}

				if (TurnsToSkip == 0)
				{
					CanMove = true;
					_logger.Log($"Player {PlayerNumber} can move again!");
				}
			}
			else if (!CanMove && TurnsToSkip == 0)
			{
				_logger.Log($"Player {PlayerNumber} is stuck in the well");
			}
		}

		public void SetWinner(bool winner)
		{
			Winner = winner;
		}

		private void HandleFirstTurnEdgeCase(int[] diceRolls)
		{
			if (diceRolls.Contains(6) && diceRolls.Contains(3))
			{
				MoveToPosition(53);
				_logger.Log($"Player {PlayerNumber} rolls {string.Join(", ", diceRolls)}");
				_logger.Log($"Player {PlayerNumber} jumped to position 53!");
			}
			else if (diceRolls.Contains(5) && diceRolls.Contains(4))
			{
				MoveToPosition(26);
				_logger.Log($"Player {PlayerNumber} rolls {string.Join(", ", diceRolls)}");
				_logger.Log($"Player {PlayerNumber} jumped to position 26!");
			}
			else
			{
				PlayTurn(diceRolls);
			}
		}
	}
}