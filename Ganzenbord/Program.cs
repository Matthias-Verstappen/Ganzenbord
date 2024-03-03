// See https://aka.ms/new-console-template for more information
using Ganzenbord.Business;

Console.WriteLine("Welcome to the goose game!");

Console.WriteLine("How many players?");
int amountOfPlayers = Int32.Parse(Console.ReadLine());

Game game = new Game(amountOfPlayers);