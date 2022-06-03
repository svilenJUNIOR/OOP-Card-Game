namespace BelotCardGame.Contracts
{
    public interface IDealer
    {
        public void DrawCards();
        public void DrawCardsSecondTime();
        public void ChooseGameType(string computerGameType, string playerGameType, string[] gametypes);
    }
}
