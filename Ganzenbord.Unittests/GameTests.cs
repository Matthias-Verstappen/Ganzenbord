using Ganzenbord.Business.Services;
using Ganzenbord.Business;
using Moq;

namespace Ganzenbord.Unittests
{
	public class GameTests
	{
		//[Fact]
		//public void WhenPlayerIsOnStart_AndRolls9_AndIsNotFirstTurn_ThenPlayerWins()
		//{
		//	// Arrange
		//	//Game game = new Game(1);
		//	var loggerMock = new Mock<ILogger>();
		//	var diceServiceMock = new Mock<IDiceService>();
		//	Game game = new Game(1, diceServiceMock.Object, loggerMock.Object);
		//	game.Turn = 2;
		//	int[] dice = { 6, 3 };
		//	Player player = game.Players.First();

		//	// Act
		//	game.PlayRound(dice);

		//	// Assert
		//	Assert.Equal(63, player.Position);
		//	Assert.True(player.Winner);
		//}

		//[Fact]
		//public void WhenPlayerRolls5And4OnFirstThrow_ThenPlayerMovesToSquare26()
		//{
		//	// Arrange
		//	var loggerMock = new Mock<ILogger>();
		//	var diceServiceMock = new Mock<IDiceService>();
		//	Game game = new Game(1, diceServiceMock.Object, loggerMock.Object);
		//	int[] dice = { 5, 4 };
		//	Player player = game.Players.First();

		//	// Act
		//	game.PlayRound(dice);

		//	// Assert
		//	Assert.Equal(26, player.Position);
		//}

		//[Fact]
		//public void WhenPlayerRolls6And3OnFirstThrow_ThenPlayerMovesToSquare53()
		//{
		//	// Arrange
		//	var loggerMock = new Mock<ILogger>();
		//	var diceServiceMock = new Mock<IDiceService>();
		//	Game game = new Game(1, diceServiceMock.Object, loggerMock.Object);
		//	int[] dice = { 6, 3 };
		//	Player player = game.Players.First();

		//	// Act
		//	game.PlayRound(dice);

		//	// Assert
		//	Assert.Equal(53, player.Position);
		//}

		//[Fact]
		//public void WhenPlayerRolls9TotalOnFirstThrow_ThenPlayerDoesNotMoveToSquare9()
		//{
		//	// Arrange
		//	//Game game = new Game(1);
		//	var loggerMock = new Mock<ILogger>();
		//	var diceServiceMock = new Mock<IDiceService>();
		//	Game game = new Game(1, diceServiceMock.Object, loggerMock.Object);
		//	int[] dice = { 6, 3 };
		//	Player player = game.Players.First();

		//	// Act
		//	game.PlayRound(dice);

		//	// Assert
		//	Assert.NotEqual(9, player.Position);
		//}

		//[Fact]
		//public void WhenPlayerThrowsTurn_PlayerMoves()
		//{
		//	// Arrange
		//	//Game game = new Game(1);
		//	var loggerMock = new Mock<ILogger>();
		//	var diceServiceMock = new Mock<IDiceService>();
		//	Game game = new Game(1, diceServiceMock.Object, loggerMock.Object);
		//	int[] dice = { 2, 4 };
		//	Player player = game.Players.First();

		//	// Act
		//	game.PlayRound(dice);

		//	// Assert
		//	Assert.NotEqual(0, player.Position);
		//}
	}
}