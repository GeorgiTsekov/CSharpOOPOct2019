namespace P01Logger.Appenders
{
    using System;
    using Contracts;
    using Layouts.Contracts;
    using P01Logger.Loggers;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout)
        {
            string typeAsLower = type.ToLower();

            switch (typeAsLower)
            {
                case "consoleappender":
                    return new ConsoleAppender(layout);
                case "fileappender":
                    return new FileAppender(layout, new LogFile());
                default:
                    throw new ArgumentException("Invalid appender type!");
            }
        }
    }
}
