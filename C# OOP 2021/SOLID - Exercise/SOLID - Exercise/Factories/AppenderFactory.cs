using System;

using SOLID___Exercise.Appenders;
using SOLID___Exercise.Enums;
using SOLID___Exercise.Layouts;
using SOLID___Exercise.Loggers;

namespace SOLID___Exercise.Factories
{
    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }
        
        public IAppender CreateAppender(string appenderType, string layoutType, string reportLevelString)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);

            ReportLevel reportLevel;

            bool hasParsed = Enum.TryParse<ReportLevel>(reportLevelString, true, out reportLevel);

            if (!hasParsed)
            {
                throw new ArgumentException("Invalid report level!");
            }

            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, reportLevel);
            }
            else if (appenderType == "FileAppender")
            {
                ILogFile logFile = new LogFile("\\data\\", "logs.txt");
                appender = new FileAppender(layout, reportLevel, logFile);
            }
            else
            {
                throw new ArgumentException("Invalid appender type!");  
            }

            return appender;
        }
    }
}
