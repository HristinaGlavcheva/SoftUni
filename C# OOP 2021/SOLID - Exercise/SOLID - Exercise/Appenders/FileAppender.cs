using System;
using SOLID___Exercise.Enums;
using SOLID___Exercise.Layouts;
    using SOLID___Exercise.Loggers;

namespace SOLID___Exercise.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, ILogFile logFile)
        {
            this.Layout = layout;
            this.LogFile = logFile;
        }

        public ILayout Layout { get; }

        public ILogFile LogFile { get; }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string datetime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                this.LogFile.Write(String.Format(this.Layout.Format, datetime, reportLevel, message));
            }
        }
    }
}
