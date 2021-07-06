using System.Collections.Generic;

using SOLID___Exercise.Appenders;
using SOLID___Exercise.Errors;

namespace SOLID___Exercise.Loggers
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Log(IError error);
    }
}
