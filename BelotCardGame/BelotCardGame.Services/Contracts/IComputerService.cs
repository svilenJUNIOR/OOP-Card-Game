using BelotCardGame.Models.Models;

namespace BelotCardGame.Services.Contracts
{
    public interface IComputerService
    {
        public string ChooseTypeOfGame(string playerGametype, List<string> gameTypes);
        public List<Card> ShowHand();
    }
}
