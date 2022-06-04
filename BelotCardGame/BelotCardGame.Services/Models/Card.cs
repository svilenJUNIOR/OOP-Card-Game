namespace BelotCardGame.Infrastructure.Models
{
    public class Card
    {
        public Card(string cardType, char suit, string color)
        {
            CardType = cardType;
            Suit = suit;
            Color = color;
        }

        public string CardType { get; set; }
        public char Suit { get; set; }
        public string Color { get; set; }
    }
}
