using BelotCardGame.Infrastructure.Models;

namespace BelotCardGame.Infrastructure.Contracts
{
    public interface IPlayerService
    {
        public void ShowHand(List<Card> Hand);
        public string ChooseGameType(string[] gameTypes);
    }
}
