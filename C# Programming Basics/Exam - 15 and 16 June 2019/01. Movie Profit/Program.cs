using System;

namespace _01._Movie_Profit
{
    class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();
            int countDays = int.Parse(Console.ReadLine());
            int countTickets = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());
            int percentForCinema = int.Parse(Console.ReadLine());

            double totalSum = countDays * countTickets * ticketPrice;
            double cinemaProfit = percentForCinema * 1.0 / 100 * totalSum;
            double studioProfit = totalSum - cinemaProfit;

            Console.WriteLine($"The profit from the movie {filmName} is {studioProfit:F2} lv.");
        }
    }
}
