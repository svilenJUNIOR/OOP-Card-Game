using BelotCardGame.Models;

namespace BelotCardGame.Contracts
{
    public interface IComputer
    {
        public void FillHand(Card card);
        public void ChooseGameType(int index, List<string> gameTypes);
    }
}
