using BelotCardGame.Models.Contracts;

namespace BelotCardGame.Models.Models
{
    public class Computer : IComputer
    {
        private List<Card> Hand { get; set; } = new List<Card>();

        public void FillHand(Card card) => Hand.Add(card);
        public List<Card> ReturnHand() => Hand;
    }
}
