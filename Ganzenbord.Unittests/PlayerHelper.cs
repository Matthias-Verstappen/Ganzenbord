using Ganzenbord.Business;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Services;
using Moq;

namespace Ganzenbord.Unittests
{
	public static class PlayerHelper
	{
		public static Player GenerateTestPlayer(int start, int[] diceRoll)
		{
			var loggerMock = new Mock<ILogger>();
			var diceMock = new Mock<IDiceService>();

			diceMock.Setup(x => x.RollDice
				(It.IsAny<int>()))
				.Returns(diceRoll);

			Player player = new Player(loggerMock.Object, diceMock.Object);
			player.MoveToPosition(start);
			return player;
		}
	}
}