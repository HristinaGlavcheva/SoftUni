using System;

namespace _04._Bachelor_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceForSinger = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int income = 0;
            int totalNumberGuests = 0;

            while (command != "The restaurant is full")
            {
                int countGuests = int.Parse(command);

                if (countGuests < 5)
                {
                    income += countGuests * 100;
                }
                else
                {
                    income += countGuests * 70;
                }

                totalNumberGuests += countGuests;
                command = Console.ReadLine();
            }

            if (income >= priceForSinger)
            {
                Console.WriteLine($"You have {totalNumberGuests} guests and {income - priceForSinger} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {totalNumberGuests} guests and {income} leva income, but no singer."); 
            }


        }
    }
}
