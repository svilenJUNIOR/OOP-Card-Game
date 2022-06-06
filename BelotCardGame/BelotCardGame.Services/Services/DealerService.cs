using BelotCardGame.Infrastructure.Constants;
using BelotCardGame.Infrastructure.Contracts;
using BelotCardGame.Infrastructure.InputOutput.Contracts;
using BelotCardGame.Infrastructure.Models;

namespace BelotCardGame.Infrastructure.Services
{
    public class DealerService : IDealerService
    {
        private readonly IScoreBoard scoreBoard;
        private readonly IComputer computer;
        private readonly IPlayer player;
        private readonly IWriter writer;
        private readonly Values values;
        public DealerService(IScoreBoard scoreBoard, IComputer computer, IPlayer player
            , IWriter writer, Values values)
        {
            this.scoreBoard = scoreBoard;
            this.computer = computer;
            this.player = player;
            this.values = values;
            this.writer = writer;
        }


        public int CollectScore(List<Card> hand, Dictionary<string, int> ScoreBoard)
        {
            int points = 0;

            foreach (var score in ScoreBoard)
            {
                for (int i = 0; i < hand.Count(); i++)
                {
                    if (hand[i].CardType == score.Key)
                        points += score.Value;
                }
            }

            return points;
        }

        public void PrintWinner(int playerScore, int computerScore)
        {
            if (playerScore > computerScore)
            {
                writer.WriteLine($"Your score: {playerScore}");
                writer.WriteLine($"Computer score: {computerScore}");
                writer.WriteLine("YOU WIN!!!");
                return;
            }
            else
            {
                writer.WriteLine($"Your score: {playerScore}");
                writer.WriteLine($"Computer score: {computerScore}");
                writer.WriteLine("YOU LOOSE!!!");
                return;
            }
        }

        public void PrintWinner(int playerScore, int computerScore, int playerBonus, int computerBonus)
        {
            if (playerScore > computerScore)
            {
                writer.WriteLine($"Your bonus: {playerBonus}");
                writer.WriteLine($"Computer bonus: {computerBonus}");

                writer.WriteLine($"Your score: {playerScore}");
                writer.WriteLine($"Computer score: {computerScore}");

                writer.WriteLine("YOU WIN!!!");
                return;
            }
            else
            {
                writer.WriteLine($"Your bonus: {playerBonus}");
                writer.WriteLine($"Computer bonus: {computerBonus}");

                writer.WriteLine($"Your score: {playerScore}");
                writer.WriteLine($"Computer score: {computerScore}");

                writer.WriteLine("YOU LOOSE!!!");
                return;
            }
        }

        public Dictionary<string, int> FillScoreBoard(Dictionary<string, int> boardToFill, string gameType)
        {
            if (gameType == "Color")
            {
                scoreBoard.FillColor();
                return boardToFill = scoreBoard.ColorScore;
            }

            else if (gameType == "AllTrumps")
            {
                scoreBoard.FillAllTrump();
                return boardToFill = scoreBoard.AllTrumpsScore;
            }

            scoreBoard.FillNoTrump();
            return boardToFill = scoreBoard.NoTrumpsScore;
        }

        public List<Card> CheckCards(List<Card> Hand)
        {
            for (int i = 0; i < Hand.Count(); i++)
                if (Hand[i].CardType == "9" || Hand[i].CardType == "J")
                    Hand[i].CardType += "C";

            return Hand;
        }
        public string GetColor(string gameType)
        {
            string color = string.Empty;

            if (gameType == "clubs" || gameType == "spades")
                color = "black";

            else if (gameType == "diamonds" || gameType == "hearts")
                color = "red";

            return color;
        }
        public int GetBonus(List<Card> Hand, string? color)
            => scoreBoard.CalculateBonus(Hand, color);

        public void DrawCards(int startIndex, int endIndex)
        {
            Random random = new Random();

            for (int i = startIndex; i <= endIndex; i++)
            {
                var randomCard = random.Next(values.cards.Length);
                var randomSuit = random.Next(values.suits.Length);
                var randomColor = random.Next(values.colors.Length);

                var cardSuit = Convert.ToChar(values.suits[randomSuit]);
                var card = values.cards[randomCard]; ;
                var cardColor = values.colors[randomColor];

                if (i <= endIndex / 2) computer.FillHand(new Card(card, cardSuit, cardColor));

                else if (i >= endIndex / 2 + 1 && i <= endIndex) player.FillHand(new Card(card, cardSuit, cardColor));
            }
        }
        public string CompareGameTypes(string computerGameType, string playerGameType, string[] gameTypes)
        {
            if (computerGameType == "give up" && playerGameType == "give up")
            {
                writer.WriteLine("Game is draw");
                return null;
            }

            int playerGameIndex = Array.IndexOf(gameTypes, playerGameType);
            int computerGameIndex = Array.IndexOf(gameTypes, computerGameType);

            writer.WriteLine("\nDealer is comparing game types!");
            Thread.Sleep(1000);

            if (playerGameIndex > computerGameIndex)
            {
                writer.WriteLine($"Game type is: {playerGameType}");
                return playerGameType;
            }

            writer.WriteLine($"Game types is: {computerGameType}");
            return computerGameType;
        }

        public void Play(string gameType, List<Card> playersHand, List<Card> computersHand)
        {
            Dictionary<string, int> ScoreBoard = null;

            int playerScore = 0;
            int computerScore = 0;

            if (gameType == "no trumps")
            {
                ScoreBoard = this.FillScoreBoard(ScoreBoard, "NoTrumps");

                playerScore = this.CollectScore(playersHand, ScoreBoard);
                computerScore = this.CollectScore(computersHand, ScoreBoard);

                this.PrintWinner(playerScore, computerScore);
            }

            else if (gameType == "all trumps")
            {
                ScoreBoard = this.FillScoreBoard(ScoreBoard, "AllTrumps");

                playerScore = this.CollectScore(playersHand, ScoreBoard);
                computerScore = this.CollectScore(computersHand, ScoreBoard);

                int playerBonus = this.GetBonus(playersHand, null);
                int computerBonus = this.GetBonus(computersHand, null);

                playerScore += playerBonus;
                computerScore += computerBonus;

                this.PrintWinner(playerScore, computerScore, playerBonus, computerBonus);
            }

            else if (gameType == "clubs" || gameType == "diamonds" || gameType == "hearts" || gameType == "spades")
            {
                string color = this.GetColor(gameType);

                playersHand = this.CheckCards(playersHand);
                computersHand = this.CheckCards(computersHand);

                ScoreBoard = this.FillScoreBoard(ScoreBoard, "Color");

                playerScore = this.CollectScore(playersHand, ScoreBoard);
                computerScore = this.CollectScore(computersHand, ScoreBoard);

                int playerBonus = this.GetBonus(playersHand, color);
                int computerBonus = this.GetBonus(computersHand, color);

                playerScore += playerBonus;
                computerScore += computerBonus;

                this.PrintWinner(playerScore, computerScore, playerBonus, computerBonus);
            }
        }
    }
}
