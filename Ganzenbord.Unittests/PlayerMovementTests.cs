using Ganzenbord.Business;

namespace Ganzenbord.Unittests
{
	public class PlayerMovementTests
	{
		[Fact]
		public void WhenPlayerRollsDice_ThenPlayerMoves()
		{
			// Arrange
			Player player = new Player();
			player.MoveToPosition(1);
			int[] dice = { 1, 2 };

			// Act
			player.Move(dice);

			// Assert
			Assert.Equal(4, player.Position);
		}

		[Fact]
		public void WhenPlayerRolls5And4OnFirstThrow_ThenPlayerMovesToSquare26()
		{
			// Arrange
			Game game = new Game(1);
			int[] dice = { 5, 4 };
			Player player = game.Players.First();

			// Act
			game.PlayRound(dice);

			// Assert
			Assert.Equal(26, player.Position);
		}

		[Fact]
		public void WhenPlayerRolls6And3OnFirstThrow_ThenPlayerMovesToSquare53()
		{
			// Arrange
			Game game = new Game(1);
			int[] dice = { 6, 3 };
			Player player = game.Players.First();

			// Act
			game.PlayRound(dice);

			// Assert
			Assert.Equal(53, player.Position);
		}

		[Fact]
		public void WhenPlayerRolls9TotalOnFirstThrow_ThenPlayerDoesNotMoveToSquare9()
		{
			// Arrange
			Game game = new Game(1);
			int[] dice = { 6, 3 };
			Player player = game.Players.First();

			// Act
			game.PlayRound(dice);

			// Assert
			Assert.NotEqual(9, player.Position);
		}

		[Fact]
		public void WhenPlayerThrowsTurn_PlayerMoves()
		{
			// Arrange
			Game game = new Game(1);
			int[] dice = { 2, 4 };
			Player player = game.Players.First();

			// Act
			game.PlayRound(dice);

			// Assert
			Assert.NotEqual(0, player.Position);
		}

		[Fact]
		public void WhenPlayerPassesSquare63_RestOfStepsAreTakenBackwards()
		{
			// Arrange
			Player player = new Player();
			//player.MoveToPosition(61);
			//int[] dice = { 1, 4 };
			player.MoveToPosition(60);
			int[] dice = { 1, 4 };

			// Act
			player.Move(dice);

			// Assert
			Assert.Equal(61, player.Position);
		}

		[Fact]
		public void WhenPlayerPassesSquare63_PlayerPositionIsNotOver63()
		{
			// Arrange
			Player player = new Player();
			player.MoveToPosition(60);
			int[] dice = { 3, 5 };

			// Act
			player.Move(dice);

			// Assert
			Assert.False(player.Position > 63);
		}
	}
}