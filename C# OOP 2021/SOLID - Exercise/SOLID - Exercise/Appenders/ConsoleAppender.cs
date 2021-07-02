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

        public void Append(string datetime, ReportType reportType, string message)
        {
            Console.WriteLine(this.Layout.Format, datetime, reportType, message);
        }
    }
}
