using Logger.Models.Contracts.Enumerations;

namespace Logger.Models.Contracts
{
    public interface IAppender
    {
        Level Level { get; }

        void Append(ILayout Layout, IError error);
    }
}
