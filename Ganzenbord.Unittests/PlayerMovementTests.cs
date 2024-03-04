using Ganzenbord.Business;

namespace Ganzenbord.Unittests
{
	public class PlayerMovementTests
	{
		[Fact]
		public void WhenPlayerRollsDice_ThenPlayerMoves()
		{
			// Arrange
			Player player = PlayerHelper.GenerateTestPlayer(1, [1, 2]);

			// Act
			player.RollDice();

			// Assert
			Assert.Equal(4, player.Position);
		}

		[Fact]
		public void WhenPlayerPassesSquare63_RestOfStepsAreTakenBackwards()
		{
			// Arrange
			Player player = PlayerHelper.GenerateTestPlayer(60, [1, 5]);

			// Act
			player.RollDice();

			// Assert
			Assert.Equal(60, player.Position);
		}

		[Fact]
		public void WhenPlayerPassesSquare63_PlayerPositionIsNotOver63()
		{
			// Arrange
			Player player = PlayerHelper.GenerateTestPlayer(60, [3, 5]);

			// Act
			player.RollDice();

			// Assert
			Assert.False(player.Position > 63);
		}
	}
}