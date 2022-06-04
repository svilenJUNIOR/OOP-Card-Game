namespace BelotCardGame.Constants
{
    public class Values
    {
        public readonly string[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        public readonly string[] suits = { "\u2663", "\u2666", "\u2665", "\u2660", };
        public readonly string[] colors = { "black", "red" };
        public readonly string[] playerGameType = { "give up", "clubs", "diamonds", "hearts", "spades", "no trumps", "all trumps" };
        public readonly List<string> computerGameType = new List<string> { "give up", "clubs", "diamonds", "hearts", "spades", "no trumps", "all trumps" };
    }
}
