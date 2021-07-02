using SOLID___Exercise.Appenders;
using SOLID___Exercise.Enums;
using System.Collections.Generic;

namespace SOLID___Exercise.Loggers
{
    public class Logger : ILogger
    {
        private List<IAppender> appenders;

        public Logger(params IAppender[] allAppenders)
        {
            this.appenders = new List<IAppender>();

            foreach (var appender in allAppenders)
            {
                this.appenders.Add(appender);
            }
        }

        public IReadOnlyCollection<IAppender> Appenders { get; }

        public void AddAppender(IAppender appender)
        {
            this.appenders.Add(appender);
        }

        public void Error(string datetime, string message)
        {
            foreach (var appender in appenders)
            {
                appender.Append(datetime, ReportType.Error, message);
            }
        }


        public void Info(string datetime, string message)
        {
            foreach (var appender in appenders)
            {
               appender.Append(datetime, ReportType.Info, message);
            }
        }
    }
}
