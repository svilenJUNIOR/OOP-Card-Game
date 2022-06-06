namespace BelotCardGame.Services.InputOutput.Contracts
{
    public interface IWriter
    {
        public void WriteLine();
        public void WriteLine(string input);
        public void Write(string input);
    }
}
