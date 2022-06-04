using BelotCardGame.Infrastructure.Contracts;

namespace BelotCardGame.Infrastructure.Models
{
    public class Player : IPlayer
    {
        private readonly IPlayerService playerService;

        public Player(IPlayerService playerService) 
            => this.playerService = playerService;

        private List<Card> Hand { get; set; } = new List<Card>();

        public void FillHand(Card card) 
            => Hand.Add(card);
        public void ShowHand() 
            => this.playerService.ShowHand(this.Hand);
        public string ChooseGameType(string[] gameTypes) 
            => this.playerService.ChooseGameType(gameTypes);
        public List<Card> ReturnHand() 
            => Hand;
    }
}
