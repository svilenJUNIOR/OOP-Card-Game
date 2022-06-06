using BelotCardGame.Infrastructure.Contracts;
using BelotCardGame.Infrastructure.InputOutput.Contracts;
using BelotCardGame.Infrastructure.Models;

namespace BelotCardGame.Infrastructure.Services
{
    public class ComputerService : IComputerService
    {
        private readonly IWriter writer;
        private readonly IComputer computer;
        public ComputerService(IWriter writer, IComputer computer)
        {
            this.writer = writer;
            this.computer = computer;
        }

        public string ChooseTypeOfGame(string playerGametype, List<string> gameTypes)
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
        public List<Card> ShowHand()
            => this.computer.ReturnHand();
    }
}
