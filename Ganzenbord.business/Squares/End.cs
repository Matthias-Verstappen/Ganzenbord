namespace Ganzenbord.Business.Squares
{
	internal class End : ISquare
	{
		public int Position { get; set; }

		public End(int position)
		{
			Position = position;
		}

		public void PlayerEntersSquare(Player player)
		{
			player.SetWinner(true);
			// Game.Instance.EndGame(); This is not the responsability of the square -> It can only control the player, not the game.
			// To win; the game should check if there is a winner
		}
	}
}