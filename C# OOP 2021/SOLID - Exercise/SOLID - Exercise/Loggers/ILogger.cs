using System.Collections.Generic;
using SOLID___Exercise.Appenders;

namespace SOLID___Exercise.Loggers
{
    public interface ILogger
    {
        IAppender[] Appenders { get; }

        void Info(string  datetime, string message);

        void Warning(string datetime, string message);

        void Error(string datetime, string message);

        void Critical(string datetime, string message);

        void Fatal(string datetime, string message);
    }
}
