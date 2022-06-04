using BelotCardGame.InputOutput.Contracts;

namespace BelotCardGame.InputOutput
{
    public class Reader : IReader
    {
        public void ReadLine() => Console.ReadLine();
    }
}
