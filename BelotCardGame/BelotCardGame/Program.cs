using BelotCardGame.Models;
using System;
using System.Text;

Random random = new Random();

var computerhand = new List<Card>();
var playerHand = new List<Card>();

var suits = new string[] { "\u2663", "\u2666", "\u2665", "\u2660", };
var colors = new string[] { "black", "red" };
var playerGameType = new string[] { "give up", "clubs", "diamonds", "hearts", "spades", "no trumps", "all trumps" };
var computerGameType = new List<string>();


for (int i = 1; i <= 10; i++)
{
    var randomNumber = random.Next(2, 11);
    var randomSuit = random.Next(suits.Length);
    var randomColor = random.Next(colors.Length);

    char cardSuit = ' ';
    var cardColor = string.Empty;
    var cardNumber = 0;

    if (randomSuit == 0) cardSuit = Convert.ToChar(suits[randomSuit]);
    else if (randomSuit == 1) cardSuit = Convert.ToChar(suits[randomSuit]);
    else if (randomSuit == 2) cardSuit = Convert.ToChar(suits[randomSuit]);
    else if (randomSuit == 3) cardSuit = Convert.ToChar(suits[randomSuit]);

    if (randomColor == 0) cardColor = "black";
    else if (randomColor == 1) cardColor = "red";

    cardNumber = randomNumber;

    if (i <= 5) computerhand.Add(new Card(cardNumber, cardSuit, cardColor));

    else if (i >= 6 && i <= 10) playerHand.Add(new Card(cardNumber, cardSuit, cardColor));
}


foreach (var card in computerhand)
    Console.WriteLine($"{card.Number}{card.Suit} - {card.Color}");

Console.WriteLine(new String('-', 100));

foreach (var card in playerHand)
    Console.WriteLine($"{card.Number}{card.Suit} - {card.Color}");