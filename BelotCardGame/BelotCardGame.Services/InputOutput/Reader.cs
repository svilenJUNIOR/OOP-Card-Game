using BelotCardGame.Services.InputOutput.Contracts;

namespace BelotCardGame.Services.InputOutput
{
    public class Reader : IReader
    {
        public void ReadLine() => Console.ReadLine();
        public int ReadInt() => int.Parse(Console.ReadLine());
    }
}
