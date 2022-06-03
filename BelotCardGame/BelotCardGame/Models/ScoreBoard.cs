using BelotCardGame.Contracts;

namespace BelotCardGame.Models
{
    public class ScoreBoard : IScoreBoard
    {
        public Dictionary<string, int> NoTrumpsScore { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> AllTrumpsScore { get;  set; } = new Dictionary<string, int>();
        public Dictionary<string, int> ColorScore { get; set; } = new Dictionary<string, int>();
    }
}
