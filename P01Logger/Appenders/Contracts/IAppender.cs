namespace P01Logger.Appenders.Contracts
{
    using Loggers.Enums;

    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        void Append(string dateTime, ReportLevel reportLevel, string messege);
    }
}
