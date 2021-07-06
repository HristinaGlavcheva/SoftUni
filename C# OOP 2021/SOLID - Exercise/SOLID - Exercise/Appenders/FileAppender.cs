using SOLID___Exercise.Enums;
using SOLID___Exercise.Errors;
using SOLID___Exercise.Layouts;
using SOLID___Exercise.Loggers;

namespace SOLID___Exercise.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, ReportLevel reportLevel, ILogFile logFile)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
            this.LogFile = logFile;
        }

        public ILayout Layout { get; }

        public ILogFile LogFile { get; }

        public ReportLevel ReportLevel { get; }

        public int CoutnMessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string FormattedMessage = this.LogFile.Write(this.Layout, error);

            System.IO.File.AppendAllText(this.LogFile.Path, FormattedMessage);
            this.CoutnMessagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.CoutnMessagesAppended}, File size: {this.LogFile.Size}";
        }
    }
}
