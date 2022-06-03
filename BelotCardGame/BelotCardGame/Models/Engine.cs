using BelotCardGame.Contracts;

namespace BelotCardGame.Models
{
    public class Engine : IEngine
    {
        private readonly string[] playerGameType =  { "give up", "clubs", "diamonds", "hearts", "spades", "no trumps", "all trumps" };
        private readonly List<string> computerGameType = new List<string> { "give up", "clubs", "diamonds", "hearts", "spades", "no trumps", "all trumps" };

        private readonly IComputer computer;
        private readonly IPlayer player;
        private readonly IDealer dealer;
        public Engine(IComputer computer, IPlayer player, IDealer dealer)
        {
            this.computer = computer;
            this.player = player;
            this.dealer = dealer;
        }
        public void Run()
        {
            dealer.DrawCards();
            player.ShowHand();
            int playerChoice = player.ChooseGameType(playerGameType);
            computer.ChooseGameType(playerChoice, computerGameType);
        }
    }
}
