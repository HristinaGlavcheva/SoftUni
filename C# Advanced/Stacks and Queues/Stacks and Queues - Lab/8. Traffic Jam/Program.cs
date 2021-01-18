using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCarsToPass = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int countPassed = 0;

            string input = Console.ReadLine();

            while(input != "end")
            {
                if(input != "green")
                {
                    cars.Enqueue(input);
                }
                else
                {
                    int carsToPass = Math.Min(cars.Count, maxCarsToPass);

                    for (int i = 1; i <= carsToPass; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        countPassed++;
                    }
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine($"{countPassed} cars passed the crossroads.");
        }
    }
}
