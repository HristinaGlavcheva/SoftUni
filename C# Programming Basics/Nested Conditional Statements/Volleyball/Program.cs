using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfYear = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int countryside = int.Parse(Console.ReadLine());

            double timePlaysNormal = 3.0 / 4 * (48 - countryside) + countryside + 2.0 / 3 * holidays;

            if (typeOfYear == "normal")
            {
                Console.WriteLine(Math.Floor(timePlaysNormal));
            }
            else
            {
                Console.WriteLine(Math.Floor(timePlaysNormal*1.15));
            }
            
        }
    }
}
