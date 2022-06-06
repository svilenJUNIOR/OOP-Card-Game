using BelotCardGame.Models.Models;

namespace BelotCardGame.Models.Contracts
{
    public interface IPlayer
    {
        public void FillHand(Card card);
        public List<Card> ReturnHand();
    }
}
