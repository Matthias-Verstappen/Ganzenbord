namespace Ganzenbord.Business.Squares
{
	internal class Prison : ISquare
	{
		public int Position { get; set; }

		public Prison(int position)
		{
			Position = position;
		}

		public void PlayerEntersSquare(Player player)
		{
			player.SetCanMove(false);
			player.SetTurnsToSkip(3);
		}
	}
}