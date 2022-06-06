using BelotCardGame.Models.Models;

namespace BelotCardGame.Services.Contracts
{
    public interface IGameService
    {
        public int CollectScore(List<Card> hand, Dictionary<string, int> ScoreBoard);
        public void PrintWinner(int playerScore, int computerScore);
        public void PrintWinner(int playerScore, int computerScore, int playerBonus, int computerBonus);
        public Dictionary<string, int> FillScoreBoard(Dictionary<string, int> boardTofill, string gameType);
        public List<Card> CheckCards(List<Card> Hand);
        public string GetColor(string gameType);
        public int GetBonus(List<Card> Hand, string? color);
        public void DrawCards(int startIndex, int endIndex);
        public string CompareGameTypes(string computerGameType, string playerGameType, string[] gameTypes);
        public void Play(string gameType, List<Card> playersHand, List<Card> computersHand);
    }
}
