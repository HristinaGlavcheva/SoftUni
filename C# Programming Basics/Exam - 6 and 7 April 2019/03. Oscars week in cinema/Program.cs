using System;

namespace _03._Oscars_week_in_cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();
            string hallType = Console.ReadLine();
            int countTickets = int.Parse(Console.ReadLine());
            double ticketPrice = 0;

            if (filmName == "A Star Is Born")
            {
                if (hallType == "normal")
                {
                    ticketPrice = 7.50;
                }
                else if (hallType == "luxury")
                {
                    ticketPrice = 10.50;
                }
                else if (filmName == "A Star Is Born" && hallType == "ultra luxury")
                {
                    ticketPrice = 13.50;
                }
            }

            else if (filmName == "Bohemian Rhapsody")
            {
                if (hallType == "normal")
                {
                    ticketPrice = 7.35;
                }
                else if (hallType == "luxury")
                {
                    ticketPrice = 9.45;
                }
                else if (hallType == "ultra luxury")
                {
                    ticketPrice = 12.75;
                }
            }

            else if (filmName == "Green Book")
            {
                if (hallType == "normal")
                {
                    ticketPrice = 8.15;
                }
                else if (hallType == "luxury")
                {
                    ticketPrice = 10.25;
                }
                else if (hallType == "ultra luxury")
                {
                    ticketPrice = 13.25;
                }
            }

            else if (filmName == "The Favourite")
            {
                if (hallType == "normal")
                {
                    ticketPrice = 8.75;
                }
                else if (hallType == "luxury")
                {
                    ticketPrice = 11.55;
                }
                else if (hallType == "ultra luxury")
                {
                    ticketPrice = 13.95;
                }
            }

            double income = ticketPrice * countTickets;
            Console.WriteLine($"{filmName} -> {income:F2} lv.");

        }
    }
}
