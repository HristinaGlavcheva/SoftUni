using System.Collections.Generic;
using SOLID___Exercise.Appenders;

namespace SOLID___Exercise.Loggers
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void AddAppender(IAppender appender);

        void Error(string  datetime, string message);

        void Info(string datetime, string message);
    }
}
