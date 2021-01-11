using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = double.Parse(Console.ReadLine());
            double coins = 0;

            while (sum > 0)
            {
                if (sum >= 2.00)
                {
                    coins += Math.Floor(sum / 2);
                    sum = sum % 2;
                }

                if (sum >= 1)
                {
                    coins++;
                    sum -= 1;
                }

                if (sum >= 0.5)
                {
                    coins++;
                    sum = Math.Round((sum % 0.5), 2);
                }

                if (sum >= 0.2)
                {
                    coins += Math.Floor(sum / 0.2);
                    sum = Math.Round((sum % 0.2), 2);
                }

                if (sum >= 0.1)
                {
                    coins++;
                    sum = Math.Round((sum - 0.1), 2);
                }

                if (sum >= 0.05)
                {
                    coins++;
                    sum = Math.Round((sum - 0.05), 2);
                }

                if (sum > 0.02)
                {
                    coins += 2;
                }

                if (sum == 0.01 || sum == 0.02)
                {
                    coins++;
                }
                break;
            }

            Console.WriteLine(coins);
        }
    }
}
