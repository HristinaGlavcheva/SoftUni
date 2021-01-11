using System;

namespace _06._Vet_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int countDays = int.Parse(Console.ReadLine());
            int countHours = int.Parse(Console.ReadLine());
            double totalSum = 0;

            for (int currentDay = 1; currentDay <= countDays; currentDay++)
            {
                double sumCurrentDay = 0;
                for (int currentHour = 1; currentHour <= countHours; currentHour++)
                {
                    if (currentDay % 2 == 0 && currentHour % 2 == 1)
                    {
                        sumCurrentDay += 2.50;
                    }
                    else if (currentDay % 2 == 1 && currentHour % 2 == 0)
                    {
                        sumCurrentDay += 1.25;
                    }
                    else
                    {
                        sumCurrentDay++; 
                    }
                }
                Console.WriteLine($"Day: {currentDay} - {sumCurrentDay:F2} leva");
                totalSum += sumCurrentDay;
            }
            Console.WriteLine($"Total: {totalSum:F2} leva");
        }
    }
}
