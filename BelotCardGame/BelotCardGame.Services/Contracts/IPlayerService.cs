using BelotCardGame.Models.Models;

namespace BelotCardGame.Services.Contracts
{
    public interface IPlayerService
    {
        public List<Card> ReturnHand();
        public string ChooseGameType(string[] gameTypes);
        public void ShowHand();
    }
}
