using BelotCardGame.Models;

Random random = new Random();

var computerhand = new List<Card>();
var playerHand = new List<Card>();

var suits = new string[] { "clubs", "spades", "hearts", "diamonds" };
var colors = new string[] { "black", "red" };
var playerGameType = new string[] { "give up", "clubs", "diamonds", "hearts", "spades", "no trumps", "all trumps" };
var computerGameType = new List<string>();

for (int i = 1; i <= 10; i++)
{
    var randomNumber = random.Next(2, 11);
    var randomSuit = random.Next(suits.Length);
    var randomColor = random.Next(colors.Length);

    var cardSuit = string.Empty;
    var cardColor = string.Empty;
    var cardNumber = 0;

    if (randomSuit == 0) cardSuit = "clubs";
    else if (randomSuit == 1) cardSuit = "spades";
    else if (randomSuit == 2) cardSuit = "hearts";
    else if (randomSuit == 3) cardSuit = "diamonds";

    if (randomColor == 0) cardColor = "black";
    else if (randomColor == 1) cardColor = "red";

    cardNumber = randomNumber;

    if (i <= 5) computerhand.Add(new Card(cardNumber, cardSuit, cardColor));

    else if (i >= 6 && i <= 10) playerHand.Add(new Card(cardNumber, cardSuit, cardColor));
}

Console.WriteLine("Your hand:");

foreach (var card in playerHand)
{
    Console.WriteLine($"{card.Color} - {card.Suit} - {card.Number}");
}

int playerGame = 0;
int computerGame = 0;

Console.WriteLine("\nChoose game type:");
for (int i = 0; i < playerGameType.Length; i++)
{
}


for (int i = playerGame; i < playerGameType.Length; i++)
{
    computerGameType.Add(playerGameType[i]);
}
computerGameType.Add("Give up");

Console.WriteLine("\nComputer Chooses game type:");
for (int i = 0; i < computerGameType.Count(); i++)
{
    Console.WriteLine($"{i}: {computerGameType[i]}");
}
Console.WriteLine($"Choosen: {computerGameType[computerGame]}");
