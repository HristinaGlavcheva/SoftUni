using System;
using System.Globalization;

using SOLID___Exercise.Common;
using SOLID___Exercise.Enums;
using SOLID___Exercise.Errors;
using SOLID___Exercise.Layouts;

namespace SOLID___Exercise.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; }

        public int CoutnMessagesAppended { get; private set; }

        public void Append(IError error)
        {
            Console.WriteLine(this.Layout.Format,
                error.DateTime.ToString(GlobalConstants.DatetimeFormat, CultureInfo.InvariantCulture),
                error.ReportLevel,
                error.Message);

            this.CoutnMessagesAppended++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.CoutnMessagesAppended}";

        }
    }
}
