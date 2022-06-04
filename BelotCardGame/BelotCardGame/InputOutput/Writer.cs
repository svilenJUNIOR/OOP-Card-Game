using BelotCardGame.InputOutput.Contracts;

namespace BelotCardGame.InputOutput
{
    public class Writer : IWriter
    {
        public void WriteLine() => Console.WriteLine();
        public void WriteLine(string input) => Console.WriteLine(input);
        public void Write(string input) => Console.Write(input);
    }
}
