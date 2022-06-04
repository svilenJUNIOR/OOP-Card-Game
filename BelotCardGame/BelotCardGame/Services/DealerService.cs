using BelotCardGame.Constants;
using BelotCardGame.Contracts;
using BelotCardGame.InputOutput.Contracts;
using BelotCardGame.Models;

namespace BelotCardGame.Services
{
    public class DealerService : IDealerService
    {
        private readonly IScoreBoard scoreBoard;
        private readonly IComputer computer;
        private readonly IPlayer player;
        private readonly IWriter writer;
        private readonly Values values;
        public DealerService (IScoreBoard scoreBoard, IComputer computer, IPlayer player, IWriter writer, Values values)
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
                this.scoreBoard.FillColor();
                return boardToFill = this.scoreBoard.ColorScore;
            }
            
            else if (gameType == "AllTrumps")
            {
                this.scoreBoard.FillAllTrump();
                return boardToFill = this.scoreBoard.AllTrumpsScore;
            }

            this.scoreBoard.FillNoTrump();
            return boardToFill = this.scoreBoard.NoTrumpsScore;
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
            => this.scoreBoard.CalculateBonus(Hand, color);

        public void FillHands(int startIndex, int endIndex)
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

                else if (i >= (endIndex / 2) + 1 && i <= endIndex) player.FillHand(new Card(card, cardSuit, cardColor));
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
    }
}
