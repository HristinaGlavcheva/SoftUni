using System;

namespace _03._Computer_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int hours = int.Parse(Console.ReadLine());
            int countPeople = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine();
            double pricePerPerson = 0;

            if (dayOrNight == "day")
            {
                if (month == "march" || month == "april" || month == "may")
                {
                    pricePerPerson = 10.50;
                }
                else if (month == "june" || month == "july" || month == "august")
                {
                    pricePerPerson = 12.60;
                }
            }
            else if(dayOrNight == "night")
            {
                if (month == "march" || month == "april" || month == "may")
                {
                    pricePerPerson = 8.40;
                }
                else if (month == "june" || month == "july" || month == "august")
                {
                    pricePerPerson = 10.20;
                }
            }
            if (countPeople >= 4)
            {
                pricePerPerson *= 0.9;
            }
            if (hours >= 5)
            {
                pricePerPerson *= 0.5;
            }

            double totalCost = pricePerPerson * countPeople * hours;
            Console.WriteLine($"Price per person for one hour: {pricePerPerson:F2}");
            Console.WriteLine($"Total cost of the visit: {totalCost:F2}");
        }
    }
}
