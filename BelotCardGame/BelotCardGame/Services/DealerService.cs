using BelotCardGame.Contracts;
using BelotCardGame.Models;

namespace BelotCardGame.Services
{
    public class DealerService : IDealerService
    {
        private readonly IScoreBoard scoreBoard;
        public DealerService (IScoreBoard scoreBoard) => this.scoreBoard = scoreBoard;

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

        public void PrintWinner(int playerScore, int computerScore, int playerBonus, int computerBonus)
        {
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
    }
}
