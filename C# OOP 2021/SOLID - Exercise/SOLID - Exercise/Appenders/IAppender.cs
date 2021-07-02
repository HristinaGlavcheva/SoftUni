using SOLID___Exercise.Enums;
using SOLID___Exercise.Layouts;

namespace SOLID___Exercise.Appenders
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }
        
        void Append(string datetime, ReportLevel reportLevel, string message);
    }
}
