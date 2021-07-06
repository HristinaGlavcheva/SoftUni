using SOLID___Exercise.Enums;
using SOLID___Exercise.Errors;
using SOLID___Exercise.Layouts;

namespace SOLID___Exercise.Appenders
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; }

        int CoutnMessagesAppended { get; }
        
        void Append(IError error);
    }
}
