using BelotCardGame.Infrastructure.Contracts;
using BelotCardGame.Infrastructure.InputOutput.Contracts;

namespace BelotCardGame.Infrastructure.Models
{
    public class Computer : IComputer
    {
        private readonly IWriter writer;
        private readonly IComputerService computerService;
        public Computer(IWriter writer, IComputerService computerService)
        {
            this.writer = writer;
            this.computerService = computerService;
        }

        private List<Card> Hand { get; set; } = new List<Card>();

        public void FillHand(Card card) => Hand.Add(card);

        public string ChooseGameType(string playerGametype, List<string> gameTypes)
        {
            Random random = new Random();
            int index = gameTypes.IndexOf(playerGametype);

            gameTypes.RemoveRange(1, index);

            writer.WriteLine("\nComputer chooses game type!");
            Thread.Sleep(1000);

            int gameIndex = random.Next(0, gameTypes.Count());
            string game = gameTypes[gameIndex];

            writer.WriteLine($"Computer choose: {game}");

            return game;
        }

        public List<Card> ReturnHand() => Hand;
    }
}
