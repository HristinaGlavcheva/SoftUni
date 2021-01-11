using System;

namespace _06._Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();
            int totalCountTickets = 0;
            int totalStudentTickets = 0;
            int totalStandardTickets = 0;
            int totalKidTickets = 0;

            while (filmName != "Finish") 
            {
                int availabeSeats = int.Parse(Console.ReadLine());
                int countTicketsPerMovie = 0;

                string command = Console.ReadLine();
                int standardTickets = 0;
                int kidTickets = 0;
                int studentTickets = 0;

                while (command != "End")
                {
                    totalCountTickets++;
                    if (command == "standard")
                    {
                        standardTickets++;
                        totalStandardTickets++;
                    }
                    else if (command == "kid")
                    {
                        kidTickets++;
                        totalKidTickets++;
                    }
                    else if (command == "student")
                    {
                        studentTickets++;
                        totalStudentTickets++;
                    }
                    countTicketsPerMovie++;
                    if (countTicketsPerMovie == availabeSeats)
                    {
                        break;
                    }

                    command = Console.ReadLine();
                }
                double percentFull = (standardTickets + kidTickets + studentTickets)*1.0 / availabeSeats * 100;
                Console.WriteLine($"{filmName} - {percentFull:F2}% full.");

                filmName = Console.ReadLine();
            }

            double percentStudentTickets = totalStudentTickets * 1.0 / totalCountTickets * 100;
            double percentStandartTickets = totalStandardTickets * 1.0 / totalCountTickets * 100;
            double percentKidsTickets = totalKidTickets * 1.0 / totalCountTickets * 100;

            Console.WriteLine($"Total tickets: {totalCountTickets}");
            Console.WriteLine($"{percentStudentTickets:F2}% student tickets.");
            Console.WriteLine($"{percentStandartTickets:F2}% standard tickets.");
            Console.WriteLine($"{percentKidsTickets:F2}% kids tickets.");
        }
    }
}
