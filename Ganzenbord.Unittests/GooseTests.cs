using Ganzenbord.Business;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Services;
using Moq;

namespace Ganzenbord.Unittests
{
	public class GooseTests
	{
		[Theory]
		[InlineData(7, new int[] { 1, 1 }, 11)]
		[InlineData(11, new int[] { 2, 1 }, 17)]
		public void WhenPlayerLandsOnGoose_GooseSendsForward(int startPosition, int[] diceRolls, int expectedPosition)
		{
			// Arrange
			Player player = PlayerHelper.GenerateTestPlayer(startPosition, diceRolls);
			player.MoveToPosition(1);
			player.MoveToPosition(startPosition);

			// Act
			player.RollDice();

			// Assert
			Assert.Equal(diceRolls.Sum(), player.DiceRolls.Sum());
			Assert.Equal(expectedPosition, player.Position);
		}

		[Theory]
		[InlineData(1, new int[] { 3, 1 }, 13)]
		[InlineData(22, new int[] { 3, 2 }, 37)]
		public void WhenPlayerLandsOnMultipleGeese_PlayerKeepsMoving(int startPosition, int[] diceRolls, int expectedPosition)
		{
			// Arrange
			Player player = PlayerHelper.GenerateTestPlayer(startPosition, diceRolls);
			player.MoveToPosition(1);
			player.MoveToPosition(startPosition);

			// Act
			player.Move(diceRolls);

			// Assert
			Assert.Equal(diceRolls.Sum(), player.DiceRolls.Sum());
			Assert.Equal(expectedPosition, player.Position);
		}

		[Theory]
		[InlineData(3, new int[] { 2, 1 }, 12)]
		public void WhenPlayerPassesGoose_ButDoesNotLandOnGoose_GooseActionIsNotTriggered(int startPosition, int[] diceRolls, int expectedPosition)
		{
			// Arrange
			Player player = PlayerHelper.GenerateTestPlayer(startPosition, diceRolls);
			player.MoveToPosition(startPosition);

			// Act
			player.Move(diceRolls);

			// Assert
			Assert.Equal(diceRolls.Sum(), player.DiceRolls.Sum());
			Assert.Equal(expectedPosition, player.Position);
		}

		[Theory]
		[InlineData(11, new int[] { 1, 1 }, 7)]
		[InlineData(22, new int[] { 3, 1 }, 10)]
		[InlineData(26, new int[] { 1, 2 }, 20)]
		public void WhenPlayerLandsOnGoose_AndReverseMovementIsTrue_GooseSendsBackwards(int startPosition, int[] diceRolls, int expectedPosition)
		{
			// Arrange
			Player player = PlayerHelper.GenerateTestPlayer(startPosition, diceRolls);
			player.ReverseMovement = true;

			// Act
			player.Move(diceRolls);

			// Assert
			Assert.Equal(diceRolls.Sum(), player.DiceRolls.Sum());
			Assert.Equal(expectedPosition, player.Position);
		}

		[Theory]
		[InlineData(61, new int[] { 3, 3 }, 53)]
		[InlineData(62, new int[] { 4, 1 }, 49)]
		[InlineData(62, new int[] { 2, 1 }, 61)]
		public void WhenPlayerPassesSquare63_AndLandsOnGoose_GooseSendsBackwards(int startPosition, int[] diceRolls, int expectedPosition)
		{
			// Arrange
			Player player = PlayerHelper.GenerateTestPlayer(startPosition, diceRolls);

			// Act
			player.Move(diceRolls);

			// Assert
			Assert.Equal(diceRolls.Sum(), player.DiceRolls.Sum());
			Assert.Equal(expectedPosition, player.Position);
		}

		[Theory]
		[InlineData(11, new int[] { 3, 3 }, 0)]
		[InlineData(20, new int[] { 6, 5 }, 0)]
		public void WhenPlayerLandsOnGoose_AndReverseMovementIsTrue_AndNewPositionIsLessThan0_NewPositionIs0(int startPosition, int[] diceRolls, int expectedPosition)
		{
			// Arrange
			Player player = PlayerHelper.GenerateTestPlayer(startPosition, diceRolls);
			player.ReverseMovement = true;

			// Act
			player.Move(diceRolls);

			// Assert
			Assert.Equal(expectedPosition, player.Position);
		}
	}
}