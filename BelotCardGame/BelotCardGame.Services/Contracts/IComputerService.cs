namespace BelotCardGame.Infrastructure.Contracts
{
    public interface IComputerService
    {
        public string ChooseTypeOfGame(string playerGametype, List<string> gameTypes);
    }
}
