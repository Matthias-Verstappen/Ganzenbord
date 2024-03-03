using Ganzenbord.Business;

namespace Ganzenbord.Unittests
{
	public class SquareTests
	{
		[Fact]
		public void WhenPlayerLandsOnBridge_PutPlayerOnSquare12()
		{
			// Arrange
			Player player = new Player();
			player.MoveToPosition(3);
			int[] dice = { 1, 2 };

			// Act

			player.Move(dice);

			// Assert
			Assert.Equal(12, player.Position);
		}

		[Fact]
		public void WhenPlayerLandsOnBridge_DoesNotPutPlayerOnSquare6()
		{
			// Arrange
			Player player = new Player();
			player.MoveToPosition(3);
			int[] dice = { 1, 2 };

			// Act
			player.Move(dice);

			// Assert
			Assert.NotEqual(6, player.Position);
		}

		[Fact]
		public void WhenPlayerLandsOnMaze_PutPlayerOnSquare39()
		{
			// Arrange
			Player player = new Player();
			player.MoveToPosition(38);
			int[] dice = { 1, 3 };

			// Act
			player.Move(dice);

			// Assert
			Assert.Equal(39, player.Position);
		}

		[Fact]
		public void WhenPlayerLandsOnMaze_DoesNotPutPlayerOnSquare42()
		{
			// Arrange
			Player player = new Player();
			player.MoveToPosition(38);
			int[] dice = { 1, 3 };

			// Act
			player.Move(dice);

			// Assert
			Assert.NotEqual(42, player.Position);
		}

		[Fact]
		public void WhenPlayerLandsOnDeath_PutPlayerBackOnStart()
		{
			// Arrange
			Player player = new Player();
			player.MoveToPosition(56);
			int[] dice = { 1, 1 };

			// Act
			player.Move(dice);

			// Assert
			Assert.Equal(0, player.Position);
		}

		[Fact]
		public void WhenPlayerLandsOnDeath_DoesNotPutPlayerOnSquare58()
		{
			// Arrange
			Player player = new Player();
			player.MoveToPosition(56);
			int[] dice = { 1, 1 };

			// Act
			player.Move(dice);

			// Assert
			Assert.NotEqual(58, player.Position);
		}

		[Fact]
		public void WhenPlayerLandsOnEnd_PlayerIsPronouncedWinner()
		{
			// Arrange
			Player player = new Player();
			player.MoveToPosition(56);
			int[] dice = { 4, 3 };

			// Act
			player.Move(dice);

			// Assert
			Assert.True(player.Winner == true);
			//Assert.True(Game.Instance.End == true);
		}

		[Fact]
		public void WhenPlayerDoesNotLandOnEnd_PlayerIsNotPronouncedWinner()
		{
			// Arrange
			Player player = new Player();
			player.MoveToPosition(13);
			int[] dice = { 4, 3 };

			// Act
			player.Move(dice);

			// Assert
			Assert.False(player.Winner == true);
		}

		[Fact]
		public void WhenPlayerLandsOnInn_SkipOneTurn()
		{
			// Arrange
			Player player = new Player();
			player.MoveToPosition(12);
			int[] diceRolls = { 5, 2 };

			// Act
			player.Move(diceRolls);

			// Assert
			Assert.Equal(1, player.TurnsToSkip);
		}

		[Fact]
		public void WhenPlayerLandsOnPrison_SkipThreeTurns()
		{
			// Arrange
			Player player = new Player();
			player.MoveToPosition(47);
			int[] diceRolls = { 3, 2 };

			// Act
			player.Move(diceRolls);

			// Assert
			Assert.Equal(3, player.TurnsToSkip);
		}

		[Fact]
		public void WhenPlayerLandsOnWell_CanMoveIsFalse()
		{
			// Arrange
			Player player = new Player();
			player.MoveToPosition(28);
			int[] diceRolls = { 2, 1 };

			// Act
			player.Move(diceRolls);

			// Assert
			Assert.True(player.CanMove == false);
		}

		[Fact]
		public void WhenPlayerLandsOnWell_SkipTurnsUntilNextPlayerLandsOnWell()
		{
			// Arrange
			Player player = new Player();
			Player player2 = new Player();
			player.MoveToPosition(28);
			player2.MoveToPosition(28);
			int[] diceRolls = { 2, 1 };

			// Act
			player.Move(diceRolls);
			player2.Move(diceRolls);

			// Assert
			Assert.True(player.CanMove == true);
			Assert.True(player2.CanMove == false);
		}
	}
}