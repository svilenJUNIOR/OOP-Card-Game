using BelotCardGame.Models;

Random random = new Random();

var computerhand = new List<Card>();
var playerHand = new List<Card>();

var cards = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
var suits = new string[] { "\u2663", "\u2666", "\u2665", "\u2660", };
var colors = new string[] { "black", "red" };

var playerGameType = new string[] { "give up", "clubs", "diamonds", "hearts", "spades", "no trumps", "all trumps" };
var computerGameType = new List<string>();


for (int i = 1; i <= 10; i++)
{
    var randomCard = random.Next(cards.Length);
    var randomSuit = random.Next(suits.Length);
    var randomColor = random.Next(colors.Length);

    var cardSuit = Convert.ToChar(suits[randomSuit]);
    var card = cards[randomCard]; ;
    var cardColor = colors[randomColor];

    if (i <= 5) computerhand.Add(new Card(card, cardSuit, cardColor));

    else if (i >= 6 && i <= 10) playerHand.Add(new Card(card, cardSuit, cardColor));
}


foreach (var card in computerhand)
{
    if (card.Color == "red")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{card.CardType}{card.Suit}");
    }
    else if (card.Color == "black")
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"{card.CardType}{card.Suit}");
    }
}
Console.ResetColor();
Console.WriteLine(new String('-', 100));

foreach (var card in playerHand)
{
    if (card.Color == "red")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{card.CardType}{card.Suit}");
    }

    else if (card.Color == "black")
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"{card.CardType}{card.Suit}");
    }
}
Console.ResetColor();