using BelotCardGame.Contracts;

namespace BelotCardGame.Models
{
    public class ScoreBoard : IScoreBoard
    {
        public Dictionary<string, int> NoTrumpsScore { get; } = new Dictionary<string, int>();
        public Dictionary<string, int> AllTrumpsScore { get; } = new Dictionary<string, int>();
        public Dictionary<string, int> ColorScore { get; } = new Dictionary<string, int>();

        public void FillNoTrump()
        {
            this.NoTrumpsScore.Add("2", 0);
            this.NoTrumpsScore.Add("3", 0);
            this.NoTrumpsScore.Add("4", 0);
            this.NoTrumpsScore.Add("5", 0);
            this.NoTrumpsScore.Add("6", 0);
            this.NoTrumpsScore.Add("7", 0);
            this.NoTrumpsScore.Add("8", 0);
            this.NoTrumpsScore.Add("9", 0);
            this.NoTrumpsScore.Add("10", 10);
            this.NoTrumpsScore.Add("J", 2);
            this.NoTrumpsScore.Add("Q", 3);
            this.NoTrumpsScore.Add("K", 4);
            this.NoTrumpsScore.Add("A", 11);
        }
        public void FillAllTrump()
        {
            this.AllTrumpsScore.Add("2", 0);
            this.AllTrumpsScore.Add("3", 0);
            this.AllTrumpsScore.Add("4", 0);
            this.AllTrumpsScore.Add("5", 0);
            this.AllTrumpsScore.Add("6", 0);
            this.AllTrumpsScore.Add("7", 0);
            this.AllTrumpsScore.Add("8", 0);
            this.AllTrumpsScore.Add("9", 14);
            this.AllTrumpsScore.Add("10", 10);
            this.AllTrumpsScore.Add("J", 20);
            this.AllTrumpsScore.Add("Q", 3);
            this.AllTrumpsScore.Add("K", 4);
            this.AllTrumpsScore.Add("A", 11);
        }
        public void FillColor()
        {
            this.ColorScore.Add("2", 0);
            this.ColorScore.Add("3", 0);
            this.ColorScore.Add("4", 0);
            this.ColorScore.Add("5", 0);
            this.ColorScore.Add("6", 0);
            this.ColorScore.Add("7", 0);
            this.ColorScore.Add("8", 0);
            this.ColorScore.Add("9", 14);
            this.ColorScore.Add("10", 10);
            this.ColorScore.Add("J", 20);
            this.ColorScore.Add("Q", 3);
            this.ColorScore.Add("K", 4);
            this.ColorScore.Add("A", 11);
        }
        public bool CollectBonuses(List<string> hand, List<List<string>> bonusTable)
        {
            bool bonus = false;

            for (int i = 0; i < bonusTable.Count(); i++)
            {
                bonus = !bonusTable[i].Except(hand).Any();
            }

            return bonus;
        }
        public void CalculateBonus(List<Card> Hand)
        {
            List<string> cardTypes = new List<string>();
            foreach (var card in Hand) cardTypes.Add(card.CardType);

            List<List<string>> smallBonuses = new List<List<string>>();
            smallBonuses = FillSmallBonuses(smallBonuses);

            List<List<string>> mediumBonuses = new List<List<string>>();
            mediumBonuses = FillMediumBonuses(mediumBonuses);

            List<List<string>> bigBonuses = new List<List<string>>();
            bigBonuses = FillBigBonuses(bigBonuses);

            List<List<string>> specialSmallBonuses = new List<List<string>>();
            specialSmallBonuses = FillSpecialSmallBonuses(specialSmallBonuses);

            List<List<string>> specialMediumBonuses = new List<List<string>>();
            specialMediumBonuses = FillSpecialMediumBonuses(specialMediumBonuses);

            List<List<string>> specialBigBonuses = new List<List<string>>();
            specialBigBonuses = FillSpecialBigBonuses(specialBigBonuses);

            bool smallBonus = CollectBonuses(cardTypes, smallBonuses);
            bool mediumBonus = CollectBonuses(cardTypes, mediumBonuses);
            bool bigBonus = CollectBonuses(cardTypes, bigBonuses);
            bool specialSmallBonus = CollectBonuses(cardTypes, specialSmallBonuses);
            bool specialmediumBonus = CollectBonuses(cardTypes, specialMediumBonuses);
            bool specialBigBonus = CollectBonuses(cardTypes, specialBigBonuses);
        }

        private List<List<string>> FillSmallBonuses(List<List<string>> smallBonuses)
        {
            smallBonuses.Add(new List<string>() { "2", "3", "4" });
            smallBonuses.Add(new List<string>() { "3", "4", "5" });
            smallBonuses.Add(new List<string>() { "4", "5", "6" });
            smallBonuses.Add(new List<string>() { "5", "6", "7" });
            smallBonuses.Add(new List<string>() { "6", "7", "8" });
            smallBonuses.Add(new List<string>() { "7", "8", "9" });
            smallBonuses.Add(new List<string>() { "8", "9", "10" });
            smallBonuses.Add(new List<string>() { "9", "10", "J" });
            smallBonuses.Add(new List<string>() { "10", "J", "Q" });
            smallBonuses.Add(new List<string>() { "J", "Q", "K" });
            smallBonuses.Add(new List<string>() { "Q", "K", "A" });

            return smallBonuses;
        }
        private List<List<string>> FillMediumBonuses(List<List<string>> mediumBonuses)
        {
            mediumBonuses.Add(new List<string>() { "2", "3", "4", "5" });
            mediumBonuses.Add(new List<string>() { "3", "4", "5", "6" });
            mediumBonuses.Add(new List<string>() { "4", "5", "6", "7" });
            mediumBonuses.Add(new List<string>() { "5", "6", "7", "8" });
            mediumBonuses.Add(new List<string>() { "6", "7", "8", "9" });
            mediumBonuses.Add(new List<string>() { "7", "8", "9", "10" });
            mediumBonuses.Add(new List<string>() { "8", "9", "10", "J" });
            mediumBonuses.Add(new List<string>() { "9", "10", "J", "Q" });
            mediumBonuses.Add(new List<string>() { "10", "J", "Q", "K" });
            mediumBonuses.Add(new List<string>() { "J", "Q", "K", "A" });

            return mediumBonuses;
        }
        private List<List<string>> FillBigBonuses(List<List<string>> bigBonuses)
        {
            bigBonuses.Add(new List<string>() { "2", "3", "4", "5", "6" });
            bigBonuses.Add(new List<string>() { "3", "4", "5", "6", "7" });
            bigBonuses.Add(new List<string>() { "4", "5", "6", "7", "8" });
            bigBonuses.Add(new List<string>() { "5", "6", "7", "8", "9" });
            bigBonuses.Add(new List<string>() { "6", "7", "8", "9", "10" });
            bigBonuses.Add(new List<string>() { "7", "8", "9", "10", "J" });
            bigBonuses.Add(new List<string>() { "8", "9", "10", "J", "Q" });
            bigBonuses.Add(new List<string>() { "9", "10", "J", "Q", "K" });
            bigBonuses.Add(new List<string>() { "10", "J", "Q", "K", "A" });
            bigBonuses.Add(new List<string>() { "K", "K", "K", "K" });
            bigBonuses.Add(new List<string>() { "Q", "Q", "Q", "Q" });
            bigBonuses.Add(new List<string>() { "10", "10", "10", "10" });
            bigBonuses.Add(new List<string>() { "A", "A", "A", "A" });

            return bigBonuses;
        }
        private List<List<string>> FillSpecialSmallBonuses(List<List<string>> specialSmallBonuses)
        {
            specialSmallBonuses.Add(new List<string>() { "Q", "K" });

            return specialSmallBonuses;
        }
        private List<List<string>> FillSpecialMediumBonuses(List<List<string>> specialMediumBonuses)
        {
            specialMediumBonuses.Add(new List<string>() { "9", "9", "9", "9" });

            return specialMediumBonuses;
        }
        private List<List<string>> FillSpecialBigBonuses(List<List<string>> specialBigBonuses)
        {
            specialBigBonuses.Add(new List<string>() { "J", "J", "J", "J" });

            return specialBigBonuses;
        }
    }
}
