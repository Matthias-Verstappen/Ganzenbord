using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.Factories
{
	public class SquareFactory : ISquareFactory
	{
		public ISquare CreateSquare(SquareType squareType, int position)
		{
			ISquare? square = null;

			square = squareType switch
			{
				SquareType.Default => new Default(position),
				SquareType.Bridge => new Bridge(position),
				SquareType.Inn => new Inn(position),
				SquareType.Well => new Well(position),
				SquareType.Maze => new Maze(position),
				SquareType.Prison => new Prison(position),
				SquareType.Death => new Death(position),
				SquareType.End => new End(position),
				SquareType.Goose => new Goose(position),
				_ => throw new ArgumentException("Invalid square type", nameof(squareType)),
			};
			return square;
		}
	}
}