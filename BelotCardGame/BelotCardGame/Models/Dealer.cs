using BelotCardGame.Contracts;

namespace BelotCardGame.Models
{
    public class Dealer : IDealer
    {
        private readonly IDealerService dealerService;
        public Dealer(IDealerService dealerService) => this.dealerService = dealerService;

        public void DrawCards(int startIndex, int endIndex)
        {
            Console.WriteLine("Dealer is drawing cards!");
            Thread.Sleep(1000);
            this.dealerService.FillHands(startIndex, endIndex);
        }

        public string ChooseGameType(string computerGameType, string playerGameType, string[] gameTypes)
             => this.dealerService.CompareGameTypes(computerGameType, playerGameType, gameTypes);

        public void Play(string gameType, List<Card> playersHand, List<Card> computersHand)
        {
            Dictionary<string, int> ScoreBoard = null;

            int playerScore = 0;
            int computerScore = 0;

            if (gameType == "no trumps")
            {
                ScoreBoard = this.dealerService.FillScoreBoard(ScoreBoard, "NoTrumps");

                playerScore = this.dealerService.CollectScore(playersHand, ScoreBoard);
                computerScore = this.dealerService.CollectScore(computersHand, ScoreBoard);

                this.dealerService.PrintWinner(playerScore, computerScore);
            }

            else if (gameType == "all trumps")
            {
                ScoreBoard = this.dealerService.FillScoreBoard(ScoreBoard, "AllTrumps");

                playerScore = this.dealerService.CollectScore(playersHand, ScoreBoard);
                computerScore = this.dealerService.CollectScore(computersHand, ScoreBoard);

                int playerBonus = this.dealerService.GetBonus(playersHand, null);
                int computerBonus = this.dealerService.GetBonus(computersHand, null);

                playerScore += playerBonus;
                computerScore += computerBonus;

                this.dealerService.PrintWinner(playerScore, computerScore, playerBonus, computerBonus);
            }

            else if (gameType == "clubs" || gameType == "diamonds" || gameType == "hearts" || gameType == "spades")
            {
                string color = this.dealerService.GetColor(gameType);

                playersHand = this.dealerService.CheckCards(playersHand);
                computersHand = this.dealerService.CheckCards(computersHand);

                ScoreBoard = this.dealerService.FillScoreBoard(ScoreBoard, "Color");

                playerScore = this.dealerService.CollectScore(playersHand, ScoreBoard);
                computerScore = this.dealerService.CollectScore(computersHand, ScoreBoard);

                int playerBonus = this.dealerService.GetBonus(playersHand, color);
                int computerBonus = this.dealerService.GetBonus(computersHand, color);

                playerScore += playerBonus;
                computerScore += computerBonus;

                this.dealerService.PrintWinner(playerScore, computerScore, playerBonus, computerBonus);
            }
        }
    }
}
