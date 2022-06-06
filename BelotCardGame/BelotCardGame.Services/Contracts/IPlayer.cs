using BelotCardGame.Infrastructure.Models;

namespace BelotCardGame.Infrastructure.Contracts
{
    public interface IPlayer
    {
        public void FillHand(Card card);
        public List<Card> ReturnHand();
    }
}
