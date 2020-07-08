namespace P01Logger.Loggers
{
    using System.Linq;
    using Contracts;

    public class LogFile : ILogFile
    {
        public int Size { get; private set; }

        public void Write(string messege)
        {
            this.Size += messege.Where(char.IsLetter).Sum(x => x);
        }
    }
}
