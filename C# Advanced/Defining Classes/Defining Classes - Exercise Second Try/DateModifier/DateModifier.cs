using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public double CalculateDifference(string firstDate, string secondDate)
        {
            DateTime startDate = DateTime.Parse(firstDate);
            DateTime endDate = DateTime.Parse(secondDate);

            double diff = (startDate - endDate).TotalDays;

            double absValue = Math.Abs(diff);

            return absValue;
        }
    }
}
