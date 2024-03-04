using Ganzenbord.Business.Squares;

namespace Ganzenbord.Business.Factories
{
    public interface ISquareFactory
    {
        ISquare CreateSquare(SquareType squareType, int position);
    }
}