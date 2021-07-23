using System;

using SOLID___Exercise.Enums;

namespace SOLID___Exercise.Errors
{
    public class Error : IError
    {
        public Error(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            this.DateTime = dateTime;
            this.ReportLevel = reportLevel;
            this.Message = message;
        }

        public DateTime DateTime { get; }

        public ReportLevel ReportLevel { get; private set; }

        public string Message { get; }
    }
}
