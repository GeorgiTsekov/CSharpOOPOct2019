namespace P01Logger.Loggers.Contracts
{
    public interface ILogger
    {
        void Info(string dateTime, string infoMessege);

        void Warning(string dateTime, string warningMessege);

        void Error(string dateTime, string errorMessege);

        void Critical(string dateTime, string criticalMessege);

        void Fatal(string dateTime, string fatalMessege);
    }
}
