using BelotCardGame.Models;

namespace BelotCardGame.Contracts
{
    public interface IPlayer
    {
        public void FillHand(Card card);
        public void ShowHand();
        public string ChooseGameType(string[] gameTypes);
        public List<Card> ReturnHand();
    }
}
