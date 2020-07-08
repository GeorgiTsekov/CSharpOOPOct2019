namespace P01Logger.Appenders
{
    using System;
    using Layouts.Contracts;
    using Loggers.Enums;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }
        

        public override void Append(string dateTime, ReportLevel reportLevel, string messege)
        {
            if (this.ReportLevel <= reportLevel)
            {
                Console.WriteLine(String.Format(this.Layout.Format, dateTime, reportLevel, messege));
            }
        }
    }
}
