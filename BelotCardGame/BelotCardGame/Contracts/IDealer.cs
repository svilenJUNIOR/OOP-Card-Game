using BelotCardGame.Models;

namespace BelotCardGame.Contracts
{
    public interface IDealer
    {
        void DrawCards(int startIndex, int endIndex);
        string ChooseGameType(string computerGameType, string playerGameType, string[] gametypes);
        void Play(string gameType, List<Card> playersHand, List<Card> computersHand);
    }
}
