using BelotCardGame.Models.Models;

namespace BelotCardGame.Services.Contracts
{
    public interface IPlayerService
    {
        public void ShowHand();
        public List<Card> ReturnHand();
        public string ChooseGameType(string[] gameTypes);
    }
}
