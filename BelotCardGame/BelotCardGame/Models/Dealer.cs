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

        public void DrawCards(int startIndex, int endIndex)
        {
            Console.WriteLine("Dealer is drawing cards!");
            Thread.Sleep(1000);

            Random random = new Random();

            for (int i = startIndex; i <= endIndex; i++)
            {
                var randomCard = random.Next(cards.Length);
                var randomSuit = random.Next(suits.Length);
                var randomColor = random.Next(colors.Length);

                var cardSuit = Convert.ToChar(suits[randomSuit]);
                var card = cards[randomCard]; ;
                var cardColor = colors[randomColor];

                if (i <= endIndex / 2) computer.FillHand(new Card(card, cardSuit, cardColor));

                else if (i >= (endIndex / 2) + 1 && i <= endIndex) player.FillHand(new Card(card, cardSuit, cardColor));
            }
        }
        
        public string ChooseGameType(string computerGameType, string playerGameType, string[] gameTypes)
        {
            if (computerGameType == "give up" && playerGameType == "give up")
            {
                Console.WriteLine("Game is draw");
                return null;
            }

            int playerGameIndex = Array.IndexOf(gameTypes, playerGameType);
            int computerGameIndex = Array.IndexOf(gameTypes, computerGameType);

            Console.WriteLine("\nDealer is comparing game types!");
            Thread.Sleep(1000);

            if (playerGameIndex > computerGameIndex)
            {
                Console.WriteLine($"Game type is: {playerGameType}");
                return playerGameType;
            }

            Console.WriteLine($"Game types is: {computerGameType}");
            return computerGameType;
        }
        public void CollectPoints(string gameType, List<Card> playersHand, List<Card> computersHand)
        {
            Dictionary<string, int> ScoreBoard = null;

            int playerScore = 0;
            int computerScore = 0;

            if (gameType == "no trumps")
            {
                this.scoreBoard.FillNoTrump();
                ScoreBoard = this.scoreBoard.NoTrumpsScore;

                foreach (var score in ScoreBoard)
                {
                    for (int i = 0; i < playersHand.Count(); i++)
                    {
                        if (playersHand[i].CardType == score.Key)
                            playerScore += score.Value;
                    }

                    for (int i = 0; i < computersHand.Count(); i++)
                    {
                        if (computersHand[i].CardType == score.Key)
                            computerScore += score.Value;
                    }
                }

                if (playerScore > computerScore)
                {
                    Console.WriteLine($"Your score: {playerScore}");
                    Console.WriteLine($"Computer score: {computerScore}");
                    Console.WriteLine("YOU WIN!!!");
                    return;
                }
                else
                {
                    Console.WriteLine($"Your score: {playerScore}");
                    Console.WriteLine($"Computer score: {computerScore}");
                    Console.WriteLine("YOU LOOSE!!!");
                    return;
                }

            }

            else if (gameType == "all trumps")
            {
                this.scoreBoard.FillAllTrump();
                ScoreBoard = this.scoreBoard.AllTrumpsScore;

                foreach (var score in ScoreBoard)
                {
                    for (int i = 0; i < playersHand.Count(); i++)
                    {
                        if (playersHand[i].CardType == score.Key)
                            playerScore += score.Value;
                    }

                    for (int i = 0; i < computersHand.Count(); i++)
                    {
                        if (computersHand[i].CardType == score.Key)
                            computerScore += score.Value;
                    }
                }

                int playerBonus = scoreBoard.CalculateBonus(playersHand, null);
                int computerBonus = scoreBoard.CalculateBonus(computersHand, null);

                playerScore += playerBonus;
                computerScore += computerBonus;

                if (playerScore > computerScore)
                {
                    Console.WriteLine($"Your bonus: {playerBonus}");
                    Console.WriteLine($"Computer bonus: {computerBonus}");

                    Console.WriteLine($"Your score: {playerScore}");
                    Console.WriteLine($"Computer score: {computerScore}");

                    Console.WriteLine("YOU WIN!!!");
                    return;
                }
                else
                {
                    Console.WriteLine($"Your bonus: {playerBonus}");
                    Console.WriteLine($"Computer bonus: {computerBonus}");

                    Console.WriteLine($"Your score: {playerScore}");
                    Console.WriteLine($"Computer score: {computerScore}");

                    Console.WriteLine("YOU LOOSE!!!");
                    return;
                }
            }

            else if (gameType == "clubs" || gameType == "diamonds" || gameType == "hearts" || gameType == "spades")
            {
                string color = string.Empty;

                if (gameType == "clubs" || gameType == "spades")
                    color = "black";

                else if (gameType == "diamonds" || gameType == "hearts")
                    color = "red";

                this.scoreBoard.FillColor();
                ScoreBoard = this.scoreBoard.ColorScore;

                for (int i = 0; i < playersHand.Count(); i++)
                    if (playersHand[i].CardType == "9" || playersHand[i].CardType == "J")
                        playersHand[i].CardType += "C";

                for (int i = 0; i < computersHand.Count(); i++)
                    if (computersHand[i].CardType == "9" || computersHand[i].CardType == "J")
                        computersHand[i].CardType += "C";

                foreach (var score in ScoreBoard)
                {
                    for (int i = 0; i < playersHand.Count(); i++)
                    {
                        if (playersHand[i].CardType == score.Key)
                            playerScore += score.Value;
                    }

                    for (int i = 0; i < computersHand.Count(); i++)
                    {
                        if (computersHand[i].CardType == score.Key)
                            computerScore += score.Value;
                    }
                }

                int playerBonus = scoreBoard.CalculateBonus(playersHand, color);
                int computerBonus = scoreBoard.CalculateBonus(computersHand, color);

                playerScore += playerBonus;
                computerScore += computerBonus;

                if (playerScore > computerScore)
                {
                    Console.WriteLine($"Your bonus: {playerBonus}");
                    Console.WriteLine($"Computer bonus: {computerBonus}");

                    Console.WriteLine($"Your score: {playerScore}");
                    Console.WriteLine($"Computer score: {computerScore}");

                    Console.WriteLine("YOU WIN!!!");
                    return;
                }
                else
                {
                    Console.WriteLine($"Your bonus: {playerBonus}");
                    Console.WriteLine($"Computer bonus: {computerBonus}");

                    Console.WriteLine($"Your score: {playerScore}");
                    Console.WriteLine($"Computer score: {computerScore}");

                    Console.WriteLine("YOU LOOSE!!!");
                    return;
                }
            }
        }
    }
}
