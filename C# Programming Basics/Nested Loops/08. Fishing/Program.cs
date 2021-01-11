using System;

namespace _08._Fishing
{
    class Program
    {
        static void Main(string[] args)
        {
            int quota = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int counter = 0;
            double profit = 0;

            while (command != "Stop")
            {
                if (counter == quota)
                {
                    Console.WriteLine("Lyubo fulfilled the quota!");
                    break;
                }
                counter++;
                double weight = double.Parse(Console.ReadLine());
                double sumAscii = 0;

                for (int i = 0; i < command.Length; i++)
                {
                    sumAscii += command[i];
                }
                double price = sumAscii / weight;

                if (counter % 3 == 0)
                {
                    profit += price;
                }
                else
                {
                    profit -= price;
                }

                command = Console.ReadLine();
            }

            if (profit >= 0)
            {
                Console.WriteLine($"Lyubo's profit from {counter} fishes is {profit:F2} leva.");
            }
            else
            {
                Console.WriteLine($"Lyubo lost {-profit:F2} leva today.");
            }
        }
    }
}
