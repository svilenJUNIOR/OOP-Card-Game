using BelotCardGame.Contracts;
using BelotCardGame.Models;
using Microsoft.Extensions.DependencyInjection;

IServiceProvider serviceProvider = new ServiceCollection()
    .AddScoped<IPlayer, Player>()
    .AddScoped<IComputer, Computer>()
    .AddScoped<IDealer, Dealer>()
    .BuildServiceProvider();

IPlayer player = serviceProvider.GetService<IPlayer>();
IComputer computer = serviceProvider.GetService<IComputer>();
IDealer dealer = serviceProvider.GetService<IDealer>();

var playerGameType = new string[] { "give up", "clubs", "diamonds", "hearts", "spades", "no trumps", "all trumps" };
var computerGameType = new List<string>() { "give up", "clubs", "diamonds", "hearts", "spades", "no trumps", "all trumps" };

dealer.DrawCards();
player.ShowHand();
int playerChoice = player.ChooseGameType(playerGameType);
computer.ChooseGameType(playerChoice, computerGameType);