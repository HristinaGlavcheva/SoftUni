using System;

namespace Football_League
{
    class Program
    {
        static void Main(string[] args)
        {
            int placesTotal = int.Parse(Console.ReadLine());
            int fansTotal = int.Parse(Console.ReadLine());
            double fansA = 0;
            double fansB = 0;
            double fansV = 0;
            double fansG = 0;

            for (int counterFans = 1; counterFans <= fansTotal; counterFans++)
            {
                string sector = Console.ReadLine();

                if (sector == "A")
                {
                    fansA++;
                }
                else if (sector == "B")
                {
                    fansB++;
                }
                else if (sector == "V")
                {
                    fansV++;
                }
                else if (sector == "G")
                {
                    fansG++;
                }
            }

            Console.WriteLine($"{(fansA / fansTotal * 100):F2}%");
            Console.WriteLine($"{(fansB / fansTotal * 100):F2}%");
            Console.WriteLine($"{(fansV / fansTotal * 100):F2}%");
            Console.WriteLine($"{(fansG / fansTotal * 100):F2}%");
            Console.WriteLine($"{(fansTotal*1.0 / placesTotal * 100):F2}%");
        }
    }
}
