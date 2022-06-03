namespace BelotCardGame.Contracts
{
    public interface IScoreBoard
    {
        public Dictionary<string, int> NoTrumpsScore { get; set; }
        public Dictionary<string, int> AllTrumpsScore { get; set; }
        public Dictionary<string, int> ColorScore { get; set; }

    }
}
