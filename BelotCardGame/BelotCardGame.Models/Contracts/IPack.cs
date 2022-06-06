using BelotCardGame.Models.Models;

namespace BelotCardGame.Models.Contracts
{
    public interface IPack
    {
        public void FillHand(Card card);
        public List<Card> ReturnHand();
    }
}
