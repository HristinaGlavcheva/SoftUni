using System;

namespace _05._Computer_Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int countComputers = int.Parse(Console.ReadLine());
            double sales = 0;
            double sumRatings = 0;

            for (int currentComputer = 1; currentComputer <= countComputers; currentComputer++)
            {
                int ratingAndSales = int.Parse(Console.ReadLine());
                int currentRating = ratingAndSales % 10;
                sumRatings += currentRating;
                double currentSales = ratingAndSales / 10;

                if(currentRating == 3)
                {
                    sales += 0.5 * currentSales;
                }
                else if (currentRating == 4)
                {
                    sales += 0.7 * currentSales;
                }
                else if (currentRating == 5)
                {
                    sales += 0.85 * currentSales;
                }
                else if (currentRating == 6)
                {
                    sales += currentSales;
                }
            }
            double averageRating = sumRatings / countComputers;
            Console.WriteLine($"{sales:F2}");
            Console.WriteLine($"{averageRating:F2}");
        }
    }
}
