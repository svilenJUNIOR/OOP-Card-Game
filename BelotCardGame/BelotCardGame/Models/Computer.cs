namespace BelotCardGame.Models
{
    public class Computer
    {
        public void ChooseGameType(int index, List<string> gameTypes)
        {
            Random random = new Random();
            gameTypes.RemoveRange(1, index);

            Console.WriteLine("Computer chooses game type!");

            int gameNumber = random.Next(0, gameTypes.Count() + 1);
            string game = gameTypes[gameNumber];

            Console.WriteLine($"Computer choose: {game}");
        }
    }
}
