using BelotCardGame.Models;

namespace BelotCardGame.Contracts
{
    public interface IComputer
    {
        public void FillHand(Card card);
        public string ChooseGameType(string index, List<string> gameTypes);
        public List<Card> ReturnHand();
    }
}
