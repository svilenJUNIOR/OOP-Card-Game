using BelotCardGame.Infrastructure.Contracts;
using BelotCardGame.Infrastructure.InputOutput.Contracts;

namespace BelotCardGame.Infrastructure.Services
{
    public class ComputerService : IComputerService
    {
        private readonly IWriter writer;
        public ComputerService(IWriter writer)
        => this.writer = writer;

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
    }
}
