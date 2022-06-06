using BelotCardGame.Models.Models;

namespace BelotCardGame.Models.Contracts
{
    public interface IScoreBoard
    {
        public Dictionary<string, int> NoTrumpsScore { get; }
        public Dictionary<string, int> AllTrumpsScore { get; }
        public Dictionary<string, int> ColorScore { get; }
        public void FillNoTrump();
        public void FillAllTrump();
        public void FillColor();
        public int CalculateBonus(List<Card> Hand, string? isGameColored);
    }
}
