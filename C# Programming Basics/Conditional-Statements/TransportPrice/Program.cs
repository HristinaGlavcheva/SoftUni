using System;

namespace ExamBook_Transport_Price
{
    class Program
    {
        static void Main(string[] args)
        {
            int distance = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine();
            double cheapestPrice;

            if (distance >= 100)
            {
                cheapestPrice = distance * 0.06;
            }
            else if (distance < 100 && distance >= 20)
            {
                cheapestPrice = distance * 0.09;
            }
            else
            {
                if (dayOrNight == "day")
                {
                    cheapestPrice = distance * 0.79 + 0.7;
                }
                else
                {
                    cheapestPrice = distance * 0.9 + 0.7;
                }
            }
            Console.WriteLine($"{cheapestPrice:F2}");
        }
    }
}
