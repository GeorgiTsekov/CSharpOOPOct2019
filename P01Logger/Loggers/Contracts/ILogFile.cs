namespace P01Logger.Loggers.Contracts
{
    public interface ILogFile
    {
        int Size { get; }

        void Write(string messege);
    }
}
