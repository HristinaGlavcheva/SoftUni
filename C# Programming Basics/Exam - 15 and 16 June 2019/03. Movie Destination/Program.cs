using System;

namespace _03._Movie_Destination
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int countDays = int.Parse(Console.ReadLine());
            double totalPrice = 0;

            if (season == "Winter")
            {
                if (destination == "Dubai")
                {
                    totalPrice = 45000 * countDays * 0.7;
                }
                else if (destination == "Sofia")
                {
                    totalPrice = 17000 * countDays * 1.25;
                }
                else if (destination == "London")
                {
                    totalPrice = 24000 * countDays;
                }
            }
            else if(season == "Summer")
            {
                if (destination == "Dubai")
                {
                    totalPrice = 40000 * countDays * 0.7;
                }
                else if (destination == "Sofia")
                {
                    totalPrice = 12500 * countDays * 1.25;
                }
                else if (destination == "London")
                {
                    totalPrice = 20250 * countDays;
                }
            }
            
            if(budget >= totalPrice)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {(budget-totalPrice):F2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {(totalPrice-budget):F2} leva more!");
            }
        }
    }
}
