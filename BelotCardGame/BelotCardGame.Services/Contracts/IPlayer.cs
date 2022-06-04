using BelotCardGame.Infrastructure.Models;

namespace BelotCardGame.Infrastructure.Contracts
{
    public interface IPlayer
    {
        public void FillHand(Card card);
        public void ShowHand();
        public string ChooseGameType(string[] gameTypes);
        public List<Card> ReturnHand();
    }
}
