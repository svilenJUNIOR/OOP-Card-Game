using BelotCardGame.Infrastructure.InputOutput.Contracts;

namespace BelotCardGame.Infrastructure.InputOutput
{
    public class Reader : IReader
    {
        public void ReadLine() => Console.ReadLine();
        public int ReadInt() => int.Parse(Console.ReadLine());
    }
}
