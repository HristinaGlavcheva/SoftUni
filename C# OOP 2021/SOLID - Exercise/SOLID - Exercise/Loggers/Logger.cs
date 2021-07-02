using System;
using SOLID___Exercise.Appenders;
using SOLID___Exercise.Enums;
using System.Collections.Generic;

namespace SOLID___Exercise.Loggers
{
    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.Appenders = appenders;
        }

        public IAppender[] Appenders
        {
            get
            {
                return this.appenders;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Appenders), "value cannot be null");
                }

                this.appenders = value;
            }
        }

        public void Info(string datetime, string message)
        {
            AppendForAllAppenders(datetime, ReportLevel.Info, message);
        }

        public void Warning(string datetime, string message)
        {
            AppendForAllAppenders(datetime, ReportLevel.Warning, message);
        }

        public void Error(string datetime, string message)
        {
            AppendForAllAppenders(datetime, ReportLevel.Error, message);
        }

        public void Critical(string datetime, string message)
        {
            AppendForAllAppenders(datetime, ReportLevel.Critical, message);
        }

        public void Fatal(string datetime, string message)
        {
            AppendForAllAppenders(datetime, ReportLevel.Fatal, message);
        }

        private void AppendForAllAppenders(string datetime, ReportLevel reportLevel, string message)
        {
            foreach (var appender in appenders)
            {
                appender.Append(datetime, reportLevel, message);
            }
        }
    }
}
