using BelotCardGame.Contracts;

namespace BelotCardGame.Models
{
    public class Computer : IComputer
    {
        private List<Card> Hand { get; set; } = new List<Card>();

        public void FillHand(Card card) => this.Hand.Add(card);

        public void ChooseGameType(int index, List<string> gameTypes)
        {
            Random random = new Random();
            gameTypes.RemoveRange(1, index);

            Console.WriteLine("Computer chooses game type!");

            int gameNumber = random.Next(0, gameTypes.Count());
            string game = gameTypes[gameNumber];

            Console.WriteLine($"Computer choose: {game}");
        }
    }
}
