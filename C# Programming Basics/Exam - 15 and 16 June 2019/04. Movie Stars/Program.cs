using System;

namespace _04._Movie_Stars
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string actorName = Console.ReadLine();
            double actorPayment = 0;

            while (actorName != "ACTION")
            {
                int countLetters = actorName.Length;
                if (countLetters > 15)
                {
                    actorPayment = 0.2 * budget;
                }
                else
                {
                    actorPayment = double.Parse(Console.ReadLine());
                }
                budget -= actorPayment;
                if (budget <= 0)
                {
                    break;
                }
                actorName = Console.ReadLine();
            }
            if (budget >= 0)
            {
                Console.WriteLine($"We are left with {budget:F2} leva.");
            }
            else
            {
                Console.WriteLine($"We need {-budget:F2} leva for our actors.");
            }
        }
    }
}
