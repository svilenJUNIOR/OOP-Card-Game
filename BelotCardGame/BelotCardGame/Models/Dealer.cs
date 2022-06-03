using BelotCardGame.Contracts;

namespace BelotCardGame.Models
{
    public class Dealer : IDealer
    {
        private readonly string[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private readonly string[] suits = { "\u2663", "\u2666", "\u2665", "\u2660", };
        private readonly string[] colors = { "black", "red" };
        private readonly IComputer computer;
        private readonly IPlayer player;
        private readonly IScoreBoard scoreBoard;
        public Dealer(IComputer computer, IPlayer player, IScoreBoard scoreBoard)
        {
            this.computer = computer;
            this.player = player;
            this.scoreBoard = scoreBoard;
        }

        public void DrawCards()
        {
            Console.WriteLine("Dealer is drawing cards!");
            Thread.Sleep(1000);

            Random random = new Random();

            for (int i = 1; i <= 10; i++)
            {
                var randomCard = random.Next(cards.Length);
                var randomSuit = random.Next(suits.Length);
                var randomColor = random.Next(colors.Length);

                var cardSuit = Convert.ToChar(suits[randomSuit]);
                var card = cards[randomCard]; ;
                var cardColor = colors[randomColor];

                if (i <= 5) computer.FillHand(new Card(card, cardSuit, cardColor));

                else if (i >= 6 && i <= 10) player.FillHand(new Card(card, cardSuit, cardColor));
            }
        }
        public void DrawCardsSecondTime()
        {
            Console.WriteLine("\nDealer is drawing cards!");
            Thread.Sleep(1000);

            Random random = new Random();

            for (int i = 1; i <= 6; i++)
            {
                var randomCard = random.Next(cards.Length);
                var randomSuit = random.Next(suits.Length);
                var randomColor = random.Next(colors.Length);

                var cardSuit = Convert.ToChar(suits[randomSuit]);
                var card = cards[randomCard]; ;
                var cardColor = colors[randomColor];

                if (i <= 3) computer.FillHand(new Card(card, cardSuit, cardColor));

                else if (i >= 4 && i <= 6) player.FillHand(new Card(card, cardSuit, cardColor));
            }
        }
        public void ChooseGameType(string computerGameType, string playerGameType, string[] gameTypes)
        {
            if (computerGameType == "give up" && playerGameType == "give up")
            {
                Console.WriteLine("Game is draw");
                return;
            }

            int playerGameIndex = Array.IndexOf(gameTypes,playerGameType);
            int computerGameIndex = Array.IndexOf(gameTypes,computerGameType);

            Console.WriteLine("\nDealer is comparing game types!");
            Thread.Sleep(1000);

            if (playerGameIndex > computerGameIndex)
                Console.WriteLine($"Game type is: {playerGameType}");

            else
                Console.WriteLine($"Game types is: {computerGameType}");
        }
    }
}
