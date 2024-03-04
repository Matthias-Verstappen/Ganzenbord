namespace Ganzenbord.Business.Services
{
	public class DiceService : IDiceService
	{
		private Random random = new Random();

		public int[] RollDice(int amountOfDice = 2)
		{
			int[] rolls = new int[amountOfDice];

			for (int i = 0; i < amountOfDice; i++)
			{
				rolls[i] = random.Next(1, 7);
			}

			return rolls;
		}
	}
}