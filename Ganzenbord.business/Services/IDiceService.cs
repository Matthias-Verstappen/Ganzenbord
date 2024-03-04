namespace Ganzenbord.Business.Services
{
	public interface IDiceService
	{
		int[] RollDice(int amountOfDice = 2);
	}
}