namespace Ganzenbord.Business.Squares
{
	internal class Goose : ISquare
	{
		public int Position { get; set; }

		public Goose(int position)
		{
			Position = position;
		}

		public void PlayerEntersSquare(Player player)
		{
			player.Move(player.DiceRolls);
		}
	}
}