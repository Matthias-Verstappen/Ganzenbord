namespace Ganzenbord.Business.Squares
{
	internal class Inn : ISquare
	{
		public int Position { get; set; }

		public Inn(int position)
		{
			Position = position;
		}

		public void PlayerEntersSquare(Player player)
		{
			player.SetCanMove(false);
			player.SetTurnsToSkip(1);
		}
	}
}