namespace Ganzenbord.Business.Squares
{
	internal class Default : ISquare
	{
		public int Position { get; set; }

		public Default(int position)
		{
			Position = position;
		}

		public void PlayerEntersSquare(Player player)
		{
		}
	}
}