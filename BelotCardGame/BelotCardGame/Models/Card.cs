namespace BelotCardGame.Models
{
    public class Card
    {
        public Card(string cardType, char suit, string color)
        {
            this.CardType = cardType;
            this.Suit = suit;
            this.Color = color;
        }

        public string CardType { get; set; }
        public char Suit { get; set; }
        public string Color { get; set; }
    }
}
