using BelotCardGame.Infrastructure.Contracts;
using BelotCardGame.Infrastructure.InputOutput.Contracts;

namespace BelotCardGame.Infrastructure.Models
{
    public class Dealer : IDealer
    {
        private readonly IDealerService dealerService;
        private readonly IWriter writer;
        public Dealer(IDealerService dealerService, IWriter writer)
        {
            this.dealerService = dealerService;
            this.writer = writer;
        }

        public void DrawCards(int startIndex, int endIndex)
        {
            writer.WriteLine("Dealer is drawing cards!");
            Thread.Sleep(1000);
            dealerService.FillHands(startIndex, endIndex);
        }

        public string ChooseGameType(string computerGameType, string playerGameType, string[] gameTypes)
             => dealerService.CompareGameTypes(computerGameType, playerGameType, gameTypes);

        public void Play(string gameType, List<Card> playersHand, List<Card> computersHand)
        {
            Dictionary<string, int> ScoreBoard = null;

            int playerScore = 0;
            int computerScore = 0;

            if (gameType == "no trumps")
            {
                ScoreBoard = dealerService.FillScoreBoard(ScoreBoard, "NoTrumps");

                playerScore = dealerService.CollectScore(playersHand, ScoreBoard);
                computerScore = dealerService.CollectScore(computersHand, ScoreBoard);

                dealerService.PrintWinner(playerScore, computerScore);
            }

            else if (gameType == "all trumps")
            {
                ScoreBoard = dealerService.FillScoreBoard(ScoreBoard, "AllTrumps");

                playerScore = dealerService.CollectScore(playersHand, ScoreBoard);
                computerScore = dealerService.CollectScore(computersHand, ScoreBoard);

                int playerBonus = dealerService.GetBonus(playersHand, null);
                int computerBonus = dealerService.GetBonus(computersHand, null);

                playerScore += playerBonus;
                computerScore += computerBonus;

                dealerService.PrintWinner(playerScore, computerScore, playerBonus, computerBonus);
            }

            else if (gameType == "clubs" || gameType == "diamonds" || gameType == "hearts" || gameType == "spades")
            {
                string color = dealerService.GetColor(gameType);

                playersHand = dealerService.CheckCards(playersHand);
                computersHand = dealerService.CheckCards(computersHand);

                ScoreBoard = dealerService.FillScoreBoard(ScoreBoard, "Color");

                playerScore = dealerService.CollectScore(playersHand, ScoreBoard);
                computerScore = dealerService.CollectScore(computersHand, ScoreBoard);

                int playerBonus = dealerService.GetBonus(playersHand, color);
                int computerBonus = dealerService.GetBonus(computersHand, color);

                playerScore += playerBonus;
                computerScore += computerBonus;

                dealerService.PrintWinner(playerScore, computerScore, playerBonus, computerBonus);
            }
        }
    }
}
