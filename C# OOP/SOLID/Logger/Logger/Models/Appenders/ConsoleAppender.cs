using Logger.Models.Contracts;
using Logger.Models.Contracts.Enumerations;

namespace Logger.Models.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public Level Level => throw new System.NotImplementedException();

        public void Append(ILayout Layout, IError error)
        {
            throw new System.NotImplementedException();
        }
    }
}
