using System;

namespace _03._Film_Premiere
{
    class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();
            string package = Console.ReadLine();
            int countTickets = int.Parse(Console.ReadLine());
            double totalBill = 0;

            if(filmName == "John Wick")
            {
                if(package == "Drink")
                {
                    totalBill = countTickets * 12;
                }
                else if (package == "Popcorn")
                {
                    totalBill = countTickets * 15;
                }
                else if (package == "Menu")
                {
                    totalBill = countTickets * 19;
                }
            }
            else if (filmName == "Star Wars")
            {
                if (package == "Drink")
                {
                    totalBill = countTickets * 18;
                }
                else if (package == "Popcorn")
                {
                    totalBill = countTickets * 25;
                }
                else if (package == "Menu")
                {
                    totalBill = countTickets * 30;
                }
                if (countTickets >= 4)
                {
                    totalBill *= 0.7;
                }
            }
            else if (filmName == "Jumanji")
            {
                if (package == "Drink")
                {
                    totalBill = countTickets * 9;
                }
                else if (package == "Popcorn")
                {
                    totalBill = countTickets * 11;
                }
                else if (package == "Menu")
                {
                    totalBill = countTickets * 14;
                }
                if (countTickets == 2)
                {
                    totalBill *= 0.85;
                }
            }
            Console.WriteLine($"Your bill is {totalBill:F2} leva.");
        }
    }
}
