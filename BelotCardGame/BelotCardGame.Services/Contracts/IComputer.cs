using BelotCardGame.Infrastructure.Models;

namespace BelotCardGame.Infrastructure.Contracts
{
    public interface IComputer
    {
        public void FillHand(Card card);
        public List<Card> ReturnHand();
    }
}
