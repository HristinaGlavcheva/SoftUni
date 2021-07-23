using SOLID___Exercise.Enums;
using System;

namespace SOLID___Exercise.Errors
{
    public interface IError
    {
        public DateTime DateTime  { get; }

        public ReportLevel ReportLevel { get; }

        public string Message { get; }
    }
}
