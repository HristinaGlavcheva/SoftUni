using System;

namespace _02._Easter_Guests
{
    class Program
    {
        static void Main(string[] args)
        {
            int countGuests = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double countEasterBreads = Math.Ceiling(countGuests*1.0 / 3);
            int countEggs = countGuests * 2;
            double finalPrice = countEasterBreads * 4 + countEggs * 0.45;

            if (budget >= finalPrice)
            {
                Console.WriteLine($"Lyubo bought {countEasterBreads} Easter bread and {countEggs} eggs.");
                Console.WriteLine($"He has {(budget-finalPrice):F2} lv. left.");
            }
            else
            {
                Console.WriteLine($"Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {(finalPrice-budget):F2} lv. more.");
            }
        }
    }
}
