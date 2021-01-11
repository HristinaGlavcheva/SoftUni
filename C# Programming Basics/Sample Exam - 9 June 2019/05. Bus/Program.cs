using System;

namespace _05._Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumberPassengers = int.Parse(Console.ReadLine());
            int numberStops = int.Parse(Console.ReadLine());
            int finalNumberPassengers = 0;

            for (int counterStops = 1; counterStops <= numberStops; counterStops++)
            {
                int numberPassengersOff = int.Parse(Console.ReadLine());
                int numberPassengersOn = int.Parse(Console.ReadLine());

                if (counterStops % 2 != 0)
                {
                    finalNumberPassengers = startNumberPassengers - numberPassengersOff + numberPassengersOn + 2;
                }
                else
                {
                    finalNumberPassengers = startNumberPassengers - numberPassengersOff + numberPassengersOn - 2;
                }

                startNumberPassengers = finalNumberPassengers;
            }

            Console.WriteLine($"The final number of passengers is : {finalNumberPassengers}");
        }
    }
}
