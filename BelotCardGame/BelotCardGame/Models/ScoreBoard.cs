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

        public int CalculateBonus(List<Card> Hand)
        {
            var hand = new List<string>();
            foreach (var card in Hand) hand.Add(card.CardType);

            bool tercaBonus = false;
            bool pedeseBonus = false;
            bool stoBonus = false;
            bool belotBonus = false;

            List<string> smallTerca = new List<string> { "10", "J", "Q" };
            List<string> riga = new List<string> { "J", "Q", "K" };
            List<string> maiorna = new List<string> { "Q", "K", "A" };

            if (!smallTerca.Except(hand).Any() || !riga.Except(hand).Any() || !maiorna.Except(hand).Any())
                tercaBonus = true;

            List<string> malkoPedese = new List<string> { "9", "10", "J", "Q" };
            List<string> rigaPedese = new List<string> { "10", "J", "Q", "K" };
            List<string> maiornoPedese = new List<string> { "J", "Q", "K", "A" };

            if (!malkoPedese.Except(hand).Any() || !rigaPedese.Except(hand).Any() || !maiornoPedese.Except(hand).Any())
                pedeseBonus = true;

            List<string> malkoSto = new List<string> { "8", "9", "10", "J", "Q" };
            List<string> rigaSto = new List<string> { "9", "10", "J", "Q", "K" };
            List<string> maiornoSto = new List<string> { "10", "J", "Q", "K", "A" };

            if (!malkoSto.Except(hand).Any() || !rigaSto.Except(hand).Any() || !maiornoSto.Except(hand).Any())
                stoBonus = true;

            List<string> belot = new List<string> { "Q", "K" };

            if (!belot.Except(hand).Any())
                belotBonus = true;

            if (stoBonus)
            {
                if (stoBonus && belotBonus) return 120;
                return 100;
            }

            if (pedeseBonus)
            {
                if (pedeseBonus && belotBonus) return 70;
                return 50;
            }
            if (tercaBonus)
            {
                if (tercaBonus && belotBonus) return 40;
                return 20;
            }

            if (belotBonus) return 20;

            return 0;
        }
    }
}
