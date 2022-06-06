using BelotCardGame.Models.Contracts;

namespace BelotCardGame.Models.Models
{
    public class ScoreBoard : IScoreBoard
    {
        public Dictionary<string, int> NoTrumpsScore { get; } = new Dictionary<string, int>();
        public Dictionary<string, int> AllTrumpsScore { get; } = new Dictionary<string, int>();
        public Dictionary<string, int> ColorScore { get; } = new Dictionary<string, int>();

        public void FillNoTrump()
        {
            NoTrumpsScore.Add("2", 0);
            NoTrumpsScore.Add("3", 0);
            NoTrumpsScore.Add("4", 0);
            NoTrumpsScore.Add("5", 0);
            NoTrumpsScore.Add("6", 0);
            NoTrumpsScore.Add("7", 0);
            NoTrumpsScore.Add("8", 0);
            NoTrumpsScore.Add("9", 0);
            NoTrumpsScore.Add("10", 10);
            NoTrumpsScore.Add("J", 2);
            NoTrumpsScore.Add("Q", 3);
            NoTrumpsScore.Add("K", 4);
            NoTrumpsScore.Add("A", 11);
        }
        public void FillAllTrump()
        {
            AllTrumpsScore.Add("2", 0);
            AllTrumpsScore.Add("3", 0);
            AllTrumpsScore.Add("4", 0);
            AllTrumpsScore.Add("5", 0);
            AllTrumpsScore.Add("6", 0);
            AllTrumpsScore.Add("7", 0);
            AllTrumpsScore.Add("8", 0);
            AllTrumpsScore.Add("9", 14);
            AllTrumpsScore.Add("10", 10);
            AllTrumpsScore.Add("J", 20);
            AllTrumpsScore.Add("Q", 3);
            AllTrumpsScore.Add("K", 4);
            AllTrumpsScore.Add("A", 11);
        }
        public void FillColor()
        {
            ColorScore.Add("2", 0);
            ColorScore.Add("3", 0);
            ColorScore.Add("4", 0);
            ColorScore.Add("5", 0);
            ColorScore.Add("6", 0);
            ColorScore.Add("7", 0);
            ColorScore.Add("8", 0);
            ColorScore.Add("9C", 14);
            ColorScore.Add("10", 10);
            ColorScore.Add("JC", 20);
            ColorScore.Add("Q", 3);
            ColorScore.Add("K", 4);
            ColorScore.Add("A", 11);
        }

        public int CalculateBonus(List<Card> Hand, string? color)
        {
            if (color != null)
            {
                var coloredHand = new List<string>();

                foreach (var card in Hand)
                    if (card.Color == color)
                        coloredHand.Add(card.CardType);
            }

            var hand = new List<string>();
            foreach (var card in Hand) hand.Add(card.CardType);

            bool tercaBonus = false;
            bool pedeseBonus = false;
            bool stoBonus = false;
            bool belotBonus = false;

            List<string> smallTerca = new List<string> { "10", "J", "Q" };
            List<string> riga = new List<string> { "J", "Q", "K" };
            List<string> maiorna = new List<string> { "Q", "K", "A" };

            List<string> malkoPedese = new List<string> { "9", "10", "J", "Q" };
            List<string> rigaPedese = new List<string> { "10", "J", "Q", "K" };
            List<string> maiornoPedese = new List<string> { "J", "Q", "K", "A" };

            List<string> malkoSto = new List<string> { "8", "9", "10", "J", "Q" };
            List<string> rigaSto = new List<string> { "9", "10", "J", "Q", "K" };
            List<string> maiornoSto = new List<string> { "10", "J", "Q", "K", "A" };

            List<string> belot = new List<string> { "Q", "K" };

            if (!smallTerca.Except(hand).Any() || !riga.Except(hand).Any() || !maiorna.Except(hand).Any())
                tercaBonus = true;

            if (!malkoPedese.Except(hand).Any() || !rigaPedese.Except(hand).Any() || !maiornoPedese.Except(hand).Any())
                pedeseBonus = true;

            if (!malkoSto.Except(hand).Any() || !rigaSto.Except(hand).Any() || !maiornoSto.Except(hand).Any())
                stoBonus = true;

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
