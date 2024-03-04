// See https://aka.ms/new-console-template for more information
using Ganzenbord.Business;
using Ganzenbord.Business.Logger;
using Ganzenbord.Business.Services;

ILogger logger = new ConsoleLogger();
IDiceService diceService = new DiceService();

Console.WriteLine("Welcome to the goose game!");

Console.WriteLine("How many players?");
int amountOfPlayers = Int32.Parse(Console.ReadLine());

//Game game = new Game(amountOfPlayers, diceService, logger); // Dependancies voor variabelen zetten
//game.Start();