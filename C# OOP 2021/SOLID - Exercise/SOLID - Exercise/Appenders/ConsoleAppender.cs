using System;
using SOLID___Exercise.Enums;
using SOLID___Exercise.Layouts;

namespace SOLID___Exercise.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public void Append(string datetime, ReportLevel reportLevel, string message)
        {
            if (this.ReportLevel <= reportLevel)
            {
                Console.WriteLine(this.Layout.Format, datetime, reportLevel, message);
            }
        }
    }
}
