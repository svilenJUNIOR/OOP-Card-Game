using BelotCardGame.Infrastructure.InputOutput.Contracts;

namespace BelotCardGame.Infrastructure.InputOutput
{
    public class Writer : IWriter
    {
        public void WriteLine() => Console.WriteLine();
        public void WriteLine(string input) => Console.WriteLine(input);
        public void Write(string input) => Console.Write(input);
    }
}
