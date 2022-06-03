using BelotCardGame.Models;

namespace BelotCardGame.Contracts
{
    public interface IDealer
    {
        void DrawCards();
        void DrawCardsSecondTime();
        string ChooseGameType(string computerGameType, string playerGameType, string[] gametypes);
        void CollectPoints(string gameType, List<Card> playersHand, List<Card> computersHand);
    }
}
