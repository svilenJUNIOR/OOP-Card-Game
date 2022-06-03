using BelotCardGame.Contracts;

namespace BelotCardGame.Models
{
    public class Computer : IComputer
    {
        private List<Card> Hand { get; set; } = new List<Card>();

        public void FillHand(Card card) => this.Hand.Add(card);

        public string ChooseGameType(string playerGametype, List<string> gameTypes)
        {
            Random random = new Random();
            int index = gameTypes.IndexOf(playerGametype);

            gameTypes.RemoveRange(1, index);

            Console.WriteLine("\nComputer chooses game type!");
            Thread.Sleep(1000);

            int gameIndex = random.Next(0, gameTypes.Count());
            string game = gameTypes[gameIndex];

            Console.WriteLine($"Computer choose: {game}");

            return game;
        }

        public List<Card> ReturnHand() => Hand;
    }
}
