using BelotCardGame.Models.Models;

namespace BelotCardGame.Models.Contracts
{
    public interface ITemp
    {
        public void FillHand(Card card);
        public List<Card> ReturnHand();
    }
}
