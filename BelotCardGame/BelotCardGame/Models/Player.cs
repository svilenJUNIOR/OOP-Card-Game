namespace BelotCardGame.Models
{
    public class Player
    {
        public List<Card> Hand { get; set; } = new List<Card>();
        public void ShowHand()
        {
            Console.WriteLine("Your hand:");

            foreach (var card in this.Hand)
            {
                if (card.Color == "red")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{card.CardType}{card.Suit}");
                }

                else if (card.Color == "black")
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{card.CardType}{card.Suit}");
                }
            }
            Console.ResetColor();
        }
        public int ChooseGameType(string[] gameTypes)
        {
            Console.WriteLine("\nChoose game type:");

            for (int i = 0; i < gameTypes.Length; i++)
            {
                Console.WriteLine($"{i}: {gameTypes[i]}");
            }

            Console.Write("Enter the number of the desired type: ");
            int choice = int.Parse(Console.ReadLine());

            return choice;
        }
    }
}
