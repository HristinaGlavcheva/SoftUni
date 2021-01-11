using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double vacationPrice = double.Parse(Console.ReadLine());
            double moneyAvailable = double.Parse(Console.ReadLine());

            int countDaysTotal = 0;
            int countDaysSpending = 0;
           
            while (vacationPrice > moneyAvailable)
            {
                string action = Console.ReadLine();
                double dailyMoney = double.Parse(Console.ReadLine());
                countDaysTotal++;

                if (action == "save")
                {
                    moneyAvailable += dailyMoney;
                    countDaysSpending = 0;
                }

                else if (action == "spend")
                {
                        countDaysSpending++;
                    
                    if (countDaysSpending >= 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine(countDaysTotal);
                        break;
                    }

                    if (dailyMoney > moneyAvailable)
                    {
                        moneyAvailable = 0;
                    }
                    else
                    {
                        moneyAvailable -= dailyMoney;
                    }
                }
            }

            if (moneyAvailable >= vacationPrice)
            {
                Console.WriteLine($"You saved the money for {countDaysTotal} days.");
            }

        }
    }
}
