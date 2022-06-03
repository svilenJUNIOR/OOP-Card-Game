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
    }
}
