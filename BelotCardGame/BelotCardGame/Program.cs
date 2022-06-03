using BelotCardGame.Models;

Player player = new Player();
Computer computer = new Computer();
Dealer dealer = new Dealer();

var computerhand = new List<Card>();



var playerGameType = new string[] { "give up", "clubs", "diamonds", "hearts", "spades", "no trumps", "all trumps" };
var computerGameType = new List<string>() { "give up", "clubs", "diamonds", "hearts", "spades", "no trumps", "all trumps" };



player.ShowHand();
int playerChoice = player.ChooseGameType(playerGameType);
computer.ChooseGameType(playerChoice, computerGameType);