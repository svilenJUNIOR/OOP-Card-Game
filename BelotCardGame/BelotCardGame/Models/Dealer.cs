﻿using BelotCardGame.Constants;
using BelotCardGame.Contracts;

namespace BelotCardGame.Models
{
    public class Dealer : IDealer
    {
        private readonly IComputer computer;
        private readonly IPlayer player;
        private readonly IDealerService dealerService;
        private readonly Values values;
        public Dealer(IComputer computer, IPlayer player,IDealerService dealerService,
            Values values)
        {
            this.computer = computer;
            this.player = player;
            this.dealerService = dealerService;
            this.values = values;
        }
        
        public void DrawCards(int startIndex, int endIndex)
        {
            Console.WriteLine("Dealer is drawing cards!");
            Thread.Sleep(1000);

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

                int playerBonus = scoreBoard.CalculateBonus(playersHand, null);
                int computerBonus = scoreBoard.CalculateBonus(computersHand, null);

                playerScore += playerBonus;
                computerScore += computerBonus;

                this.dealerService.PrintWinner(playerScore, computerScore, playerBonus, computerBonus);
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

                ScoreBoard = this.dealerService.FillScoreBoard(ScoreBoard, "Color");

                playerScore = this.dealerService.CollectScore(playersHand, ScoreBoard);
                computerScore = this.dealerService.CollectScore(computersHand, ScoreBoard);

                int playerBonus = scoreBoard.CalculateBonus(playersHand, color);
                int computerBonus = scoreBoard.CalculateBonus(computersHand, color);

                playerScore += playerBonus;
                computerScore += computerBonus;

                this.dealerService.PrintWinner(playerScore, computerScore, playerBonus, computerBonus);
            }
        }
    }
}
