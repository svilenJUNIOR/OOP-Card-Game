namespace BelotCardGame.Models
{
    public class Dealer
    {
        private readonly string[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private readonly string[] suits = { "\u2663", "\u2666", "\u2665", "\u2660", };
        private readonly string[] colors = { "black", "red" };
        public Dealer()
        {

        }

        public void DrawCards()
        {
            Random random = new Random();

            for (int i = 1; i <= 10; i++)
            {
                var randomCard = random.Next(cards.Length);
                var randomSuit = random.Next(suits.Length);
                var randomColor = random.Next(colors.Length);

                var cardSuit = Convert.ToChar(suits[randomSuit]);
                var card = cards[randomCard]; ;
                var cardColor = colors[randomColor];

                if (i <= 5) computer.Hand.Add(new Card(card, cardSuit, cardColor));

                else if (i >= 6 && i <= 10) player.Hand.Add(new Card(card, cardSuit, cardColor));
            }
        }
    }
}
