using SOLID___Exercise.Enums;
using SOLID___Exercise.Layouts;

namespace SOLID___Exercise.Appenders
{
    public interface IAppender
    {
        ILayout Layout { get; }
        
        void Append(string datetime, ReportType reportType, string message);
    }
}
