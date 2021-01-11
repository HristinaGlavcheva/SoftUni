using System;

namespace CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double sumToConvert = double.Parse(Console.ReadLine());
            string currencyToConvert = Console.ReadLine();
            string currencyToReceive = Console.ReadLine();
            double courseBGN = 1;
            double courseUSD = 1.79549;
            double courseEUR = 1.95583;
            double courseGBP = 2.53405;
            double result=sumToConvert;
           
            if(currencyToConvert == "BGN")
            {
                result = courseBGN * sumToConvert;
            }

            if (currencyToConvert == "USD")
            {
                result = courseUSD * sumToConvert;
            }

            if (currencyToConvert == "EUR")
            {
                result = courseEUR * sumToConvert;
            }

            if (currencyToConvert == "GBP")
            {
                result = courseGBP * sumToConvert;
            }

            Console.WriteLine(Math.Round(result, 2));

        }
    }
}
