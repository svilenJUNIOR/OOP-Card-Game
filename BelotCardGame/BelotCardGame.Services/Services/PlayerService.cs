using BelotCardGame.Models.Contracts;
using BelotCardGame.Models.Models;
using BelotCardGame.Services.Contracts;
using BelotCardGame.Services.InputOutput.Contracts;

namespace BelotCardGame.Services.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly Player player;
        public PlayerService(IWriter writer, IReader reader, Player player)
        {
            this.writer = writer;
            this.reader = reader;
            this.player = player;
        }
        public void ShowHand()
        {
            var Hand = player.ReturnHand();
            writer.WriteLine("Your hand:");

            foreach (var card in Hand)
            {
                if (card.Color == "red")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    writer.WriteLine($"{card.CardType}{card.Suit}");
                }

                else if (card.Color == "black")
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    writer.WriteLine($"{card.CardType}{card.Suit}");
                }
            }
            Console.ResetColor();
        }
        public List<Card> ReturnHand() => player.ReturnHand();
        public string ChooseGameType(string[] gameTypes)
        {
            writer.WriteLine("\nChoose game type:");

            for (int i = 0; i < gameTypes.Length; i++)
            {
                writer.WriteLine($"{i}: {gameTypes[i]}");
            }

            writer.Write("Enter the number of the desired type: ");
            int gameindex = reader.ReadInt();

            if (gameindex < 0 || gameindex > gameTypes.Length)
                throw new ArgumentException("Invalid number of game type!");

            string game = gameTypes[gameindex];
            return game;
        }
    }
}
