using BelotCardGame.Models;

namespace BelotCardGame.Contracts
{
    public interface IPlayer
    {
        public void FillHand(Card card);
        public void ShowHand();
        public int ChooseGameType(string[] gameTypes);
    }
}
