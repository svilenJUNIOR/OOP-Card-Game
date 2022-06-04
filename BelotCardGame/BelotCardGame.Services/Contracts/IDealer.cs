using BelotCardGame.Infrastructure.Models;

namespace BelotCardGame.Infrastructure.Contracts
{
    public interface IDealer
    {
        void DrawCards(int startIndex, int endIndex);
        string ChooseGameType(string computerGameType, string playerGameType, string[] gametypes);
        void Play(string gameType, List<Card> playersHand, List<Card> computersHand);
    }
}
