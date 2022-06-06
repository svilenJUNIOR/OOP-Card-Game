using BelotCardGame.Models.Contracts;

namespace BelotCardGame.Models.Models
{
    public class Temp : ITemp
    {
        private readonly List<Card> Hand  = new List<Card>();
        public void FillHand(Card card) => this.Hand.Add(card);
        public List<Card> ReturnHand() => this.Hand;
    }
}
