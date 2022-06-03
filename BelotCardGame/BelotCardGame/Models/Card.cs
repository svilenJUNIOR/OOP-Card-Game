namespace BelotCardGame.Models
{
    public class Card
    {
        public Card(int number, string suit, string color)
        {
            this.Number = number;
            this.Suit = suit;
            this.Color = color;
        }

        public int Number { get; set; }
        public string Suit { get; set; }
        public string Color { get; set; }
    }
}
