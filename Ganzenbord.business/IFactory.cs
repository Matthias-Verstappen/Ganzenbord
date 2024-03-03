using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business
{
	public interface IFactory
	{
		ISquare CreateSquare(SquareType squareType, int position);
	}
}