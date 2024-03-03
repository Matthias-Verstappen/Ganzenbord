using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business
{
	public class Player() // ILogger logger
	{
		//private readonly ILogger _logger = logger;

		//public PlayerColor PlayerColor { get; private set; }
		public int Position { get; private set; } = 0;

		public bool CanMove { get; private set; } = true;

		public int TurnsToSkip { get; private set; } = 0;

		public bool Winner { get; private set; } = false;

		public bool ReverseMovement { get; set; } = false;

		public int[] DiceRolls { get; private set; }

		private int boardSize = Board.Instance.Squares.Count - 1;

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
				}
				else
				{
					ReverseMovement = true;
					Position = boardSize - (newPosition - boardSize);
				}
			}
			else
			{
				Position -= diceRolls.Sum();
				if (Position < 0)
				{
					Position = 0;
				}
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
			square.PlayerEntersSquare(this);
		}

		public void SetCanMove(bool canMove)
		{
			CanMove = canMove;
		}

		public void SetTurnsToSkip(int amountTurns)
		{
			TurnsToSkip = amountTurns;
		}

		public void PlayTurn(int[] diceRolls)
		{
			if (CanMove)
			{
				DiceRolls = diceRolls;
				Move(diceRolls);
				ReverseMovement = false;
			}
			else if (TurnsToSkip > 0)
			{
				TurnsToSkip--;

				if (TurnsToSkip == 0)
				{
					CanMove = true;
				}
			}
		}

		public void SetWinner(bool winner)
		{
			Winner = winner;
		}
	}
}