using System;
using System.Globalization;
using SOLID___Exercise.Common;
using SOLID___Exercise.Enums;
using SOLID___Exercise.Errors;

namespace SOLID___Exercise.Factories
{
    public class ErrorFactory
    {
        public IError CreateError(string datetimeString, string reportLevelString, string message)
        {
            DateTime datetime;

            try
            {
                datetime = DateTime.ParseExact(datetimeString, GlobalConstants.DatetimeFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid date format!", e);
            }

            ReportLevel reportLevel;

            bool hasParsed = Enum.TryParse<ReportLevel>(reportLevelString, true, out reportLevel);

            if (!hasParsed)
            {
                throw new ArgumentException("Invalid report level type!");
            }

            IError error = new Error(datetime, reportLevel, message);

            return error;
        }
    }
}
