using BelotCardGame.Infrastructure.Constants;
using BelotCardGame.Infrastructure.Contracts;

namespace BelotCardGame.Engine
{
    public class Engine : IEngine
    {
        private readonly IComputer computer;
        private readonly IPlayer player;
        private readonly IDealer dealer;
        private readonly Values values;
        public Engine(IComputer computer, IPlayer player, IDealer dealer, Values values)
        {
            this.computer = computer;
            this.player = player;
            this.dealer = dealer;
            this.values = values;
        }
        public void Run()
        {
            dealer.DrawCards(1, 10);
            player.ShowHand();
            string playerChoice = player.ChooseGameType(values.playerGameType);
            string computerChoice = computer.ChooseGameType(playerChoice, values.computerGameType);
            string choosenGameType = dealer.ChooseGameType(computerChoice, playerChoice, values.playerGameType);
            dealer.DrawCards(1, 6);
            player.ShowHand();
            dealer.Play(choosenGameType, player.ReturnHand(), computer.ReturnHand());
        }
    }
}
