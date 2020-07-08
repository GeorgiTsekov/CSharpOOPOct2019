namespace P01Logger.Loggers
{
    using Layouts.Contracts;
    using Contracts;
    using Enums;
    using Appenders;
    using System;
    using System.IO;

    public class FileAppender : Appender
    {
        private const string Path = @"..\..\..\log.txt";
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string dateTime, ReportLevel reportLevel, string messege)
        {
            string content = String.Format(this.Layout.Format, dateTime, reportLevel, messege) + Environment.NewLine;

            if (this.ReportLevel <= reportLevel)
            {
                File.AppendAllText(Path, content);
            }
        }
    }
}
