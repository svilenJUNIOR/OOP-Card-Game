using BelotCardGame.Models;

namespace BelotCardGame.Contracts
{
    public interface IDealerService
    {
        public int CollectScore(List<Card> hand, Dictionary<string, int> ScoreBoard);
        public void PrintWinner(int playerScore, int computerScore);
        public void PrintWinner(int playerScore, int computerScore, int playerBonus, int computerBonus);
        public Dictionary<string, int> FillScoreBoard(Dictionary<string, int> boardTofill, string gameType);
    }
}
