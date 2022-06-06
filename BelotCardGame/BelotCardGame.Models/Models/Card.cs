namespace BelotCardGame.Models.Models
{
    public class Card
    {
        private string type;
        private char suit;
        private string color;
        public Card(string cardType, char suit, string color)
        {
            CardType = cardType;
            Suit = suit;
            Color = color;
        }

        public string CardType
        {
            get { return type; }
            set
            {
                if (!new List<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" }.Contains(value))
                {
                    throw new ArgumentException("Invalid card type!");
                }

                type = value;
            }
        }
        public char Suit
        {
            get { return suit; }
            set
            {
                if (!new List<string> { "\u2663", "\u2666", "\u2665", "\u2660", }.Contains(value.ToString()))
                {
                    throw new ArgumentException("Invalid card suit!");
                }

                suit = value;
            }
        }
        public string Color
        {
            get { return color; }
            set
            {
                if (!new List<string> { "red", "black" }.Contains(value))
                {
                    throw new ArgumentException("Invalid card color!");
                }

                color = value;
            }
        }
    }
}
