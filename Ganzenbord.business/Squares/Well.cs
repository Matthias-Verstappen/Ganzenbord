namespace Ganzenbord.Business.Squares
{
	internal class Well : ISquare
	{
		public int Position { get; set; }

		public Well(int position)
		{
			Position = position;
		}

		public Player? TrappedPlayer { get; set; } = null;
		//private Player? FreedPlayer { get; set; } = null;

		public void PlayerEntersSquare(Player player)
		{
			if (TrappedPlayer == null)
			{
				TrappedPlayer = player;
				player.SetCanMove(false);
			}
			else
			{
				//FreedPlayer = TrappedPlayer;
				//FreedPlayer.SetCanMove(true);
				TrappedPlayer.SetCanMove(true);
				TrappedPlayer = player;
				TrappedPlayer.SetCanMove(false);
			}
		}
	}
}