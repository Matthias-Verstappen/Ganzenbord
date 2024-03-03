using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business
{
	public class Factory : IFactory
	{
		public ISquare CreateSquare(SquareType squareType, int position)
		{
			ISquare? square = null;

			switch (squareType)
			{
				case SquareType.Default:
					square = new Default(position);
					break;

				case SquareType.Bridge:
					square = new Bridge(position);
					break;

				case SquareType.Inn:
					square = new Inn(position);
					break;

				case SquareType.Well:
					square = new Well(position);
					break;

				case SquareType.Maze:
					square = new Maze(position);
					break;

				case SquareType.Prison:
					square = new Prison(position);
					break;

				case SquareType.Death:
					square = new Death(position);
					break;

				case SquareType.End:
					square = new End(position);
					break;

				case SquareType.Goose:
					square = new Goose(position);
					break;

				default:
					throw new ArgumentException("Invalid square type", nameof(squareType));
			}

			return square;
		}
	}
}