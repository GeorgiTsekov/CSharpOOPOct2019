namespace P01Logger.Appenders
{
    using Contracts;
    using Layouts.Contracts;
    using Loggers.Enums;

    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        protected ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string dateTime, ReportLevel reportLevel, string messege);
    }
}
