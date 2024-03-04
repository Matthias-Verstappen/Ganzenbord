using Ganzenbord.Business.Factories;
using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business
{
    public class Board
	{
		public List<ISquare> Squares { get; set; } = new();

		private static Board instance;

		public static Board Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Board();
				}

				return instance;
			}
		}

		private ISquareFactory factory;

		private Board()
		{
			this.factory = new SquareFactory();
			SetupBoard();
		}

		private readonly Dictionary<int, SquareType> squareTypeMapping = new()
		{
			{ 6, SquareType.Bridge },
			{ 19, SquareType.Inn },
			{ 31, SquareType.Well },
			{ 42, SquareType.Maze },
			{ 52, SquareType.Prison },
			{ 58, SquareType.Death },
			{ 63, SquareType.End },
			{ 5, SquareType.Goose },
			{ 9, SquareType.Goose },
			{ 14, SquareType.Goose },
			{ 18, SquareType.Goose },
			{ 23, SquareType.Goose },
			{ 27, SquareType.Goose },
			{ 32, SquareType.Goose },
			{ 36, SquareType.Goose },
			{ 41, SquareType.Goose },
			{ 45, SquareType.Goose },
			{ 50, SquareType.Goose },
			{ 54, SquareType.Goose },
			{ 59, SquareType.Goose },
		};

		private void SetupBoard()
		{
			int boardSize = 64;
			for (int i = 0; i < boardSize; i++)
			{
				SquareType squareType;

				if (squareTypeMapping.TryGetValue(i, out squareType))
				{
					ISquare square = factory.CreateSquare(squareType, i);
					Squares.Add(square);
				}
				else
				{
					ISquare square = factory.CreateSquare(SquareType.Default, i);
					Squares.Add(square);
				}
			}
		}
	}
}