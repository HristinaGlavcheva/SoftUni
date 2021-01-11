using System;

namespace DailyEarnings
{
    class Program
    {
        static void Main(string[] args)
        {
            int workDaysPerMonth = int.Parse(Console.ReadLine());
            double usdPerDay = double.Parse(Console.ReadLine());
            double currencyCourse = double.Parse(Console.ReadLine());
            double monthIncomeUSD = workDaysPerMonth * usdPerDay;
            double totalIncomeUSD = (monthIncomeUSD * 12) + (monthIncomeUSD * 2.5);
            double netIncomePerYearUSD = totalIncomeUSD * 0.75;
            double netIncomePerDayUSD = netIncomePerYearUSD / 365;
            double DailyEarningsLV = netIncomePerDayUSD * currencyCourse;
            Console.WriteLine($"{DailyEarningsLV:F2}");
         }
    }
}
