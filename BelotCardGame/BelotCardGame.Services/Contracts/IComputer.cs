using BelotCardGame.Infrastructure.Models;

namespace BelotCardGame.Infrastructure.Contracts
{
    public interface IComputer
    {
        public void FillHand(Card card);
        public string ChooseGameType(string index, List<string> gameTypes);
        public List<Card> ReturnHand();
    }
}
