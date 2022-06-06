using BelotCardGame.Infrastructure.Models;

namespace BelotCardGame.Infrastructure.Contracts
{
    public interface IPlayerService
    {
        public void ShowHand();
        public List<Card> ReturnHand();
        public string ChooseGameType(string[] gameTypes);
    }
}
