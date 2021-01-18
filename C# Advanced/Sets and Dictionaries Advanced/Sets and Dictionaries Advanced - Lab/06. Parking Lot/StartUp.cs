using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            HashSet<string> cars = new HashSet<string>();

            while(command[0] != "END")
            {
                string carNumber = command[1];
                
                if(command[0] == "IN")
                {
                    cars.Add(carNumber);
                }
                else if (command[0] == "OUT")
                {
                    if (cars.Contains(carNumber))
                    {
                        cars.Remove(carNumber);
                    }
                }

                command = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            if(cars.Count > 0)
            {
                foreach (var carNumber in cars)
                {
                    Console.WriteLine(carNumber);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
