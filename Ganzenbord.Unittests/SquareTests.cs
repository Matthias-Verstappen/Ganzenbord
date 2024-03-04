using Ganzenbord.Business;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Services;
using Moq;

namespace Ganzenbord.Unittests
{
	public class SquareTests
	{
		[Fact]
		public void WhenPlayerLandsOnBridge_PutPlayerOnSquare12()
		{
			// Arrange
			Player player = PlayerHelper.GenerateTestPlayer(3, [1, 2]);

			// Act
			player.RollDice();

			// Assert
			Assert.Equal(12, player.Position);
			Assert.NotEqual(6, player.Position);
		}

		[Fact]
		public void WhenPlayerLandsOnMaze_PutPlayerOnSquare39()
		{
			// Arrange
			Player player = PlayerHelper.GenerateTestPlayer(38, [1, 3]);

			// Act
			player.RollDice();

			// Assert
			Assert.Equal(39, player.Position);
			Assert.NotEqual(42, player.Position);
		}

		[Fact]
		public void WhenPlayerLandsOnDeath_PutPlayerBackOnStart()
		{
			// Arrange
			Player player = PlayerHelper.GenerateTestPlayer(56, [1, 1]);

			// Act
			player.RollDice();

			// Assert
			Assert.Equal(0, player.Position);
			Assert.NotEqual(58, player.Position);
		}

		[Fact]
		public void WhenPlayerLandsOnEnd_PlayerIsPronouncedWinner()
		{
			// Arrange
			Player player = PlayerHelper.GenerateTestPlayer(56, [4, 3]);

			// Act
			player.RollDice();

			// Assert
			Assert.True(player.Winner);
		}

		[Fact]
		public void WhenPlayerDoesNotLandOnEnd_PlayerIsNotPronouncedWinner()
		{
			// Arrange
			Player player = PlayerHelper.GenerateTestPlayer(13, [4, 3]);

			// Act
			player.RollDice();

			// Assert
			Assert.False(player.Winner);
		}

		[Fact]
		public void WhenPlayerLandsOnInn_SkipOneTurn()
		{
			// Arrange
			Player player = PlayerHelper.GenerateTestPlayer(12, [4, 3]);

			// Act
			player.RollDice();

			// Assert
			Assert.Equal(1, player.TurnsToSkip);
		}

		[Fact]
		public void WhenPlayerLandsOnPrison_SkipThreeTurns()
		{
			// Arrange
			Player player = PlayerHelper.GenerateTestPlayer(47, [2, 3]);

			// Act
			player.RollDice();

			// Assert
			Assert.Equal(3, player.TurnsToSkip);
		}

		[Fact]
		public void WhenPlayerLandsOnWell_CanMoveIsFalse()
		{
			// Arrange
			Player player = PlayerHelper.GenerateTestPlayer(28, [2, 1]);

			// Act
			player.RollDice();

			// Assert
			Assert.False(player.CanMove);
		}

		[Fact]
		public void WhenPlayerLandsOnWell_SkipTurnsUntilNextPlayerLandsOnWell()
		{
			// Arrange
			//Player player = new Player();
			Player player1 = PlayerHelper.GenerateTestPlayer(28, [2, 1]);
			Player player2 = PlayerHelper.GenerateTestPlayer(28, [2, 1]);

			// Act
			player1.RollDice();
			player2.RollDice();

			// Assert
			Assert.True(player1.CanMove);
			Assert.False(player2.CanMove);
		}
	}
}