using BelotCardGame.Infrastructure.Contracts;
using BelotCardGame.Infrastructure.InputOutput.Contracts;

namespace BelotCardGame.Infrastructure.Models
{
    public class Computer : IComputer
    {
        private readonly IComputerService computerService;
        public Computer(IComputerService computerService)
         => this.computerService = computerService;

        private List<Card> Hand { get; set; } = new List<Card>();

        public void FillHand(Card card) => Hand.Add(card);

        public string ChooseGameType(string playerGametype, List<string> gameTypes)
         => this.computerService.ChooseTypeOfGame(playerGametype, gameTypes);

        public List<Card> ReturnHand() => Hand;
    }
}
