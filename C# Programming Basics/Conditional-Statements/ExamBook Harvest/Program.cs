using System;

namespace ExamBook_Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            int vineyardSqM = int.Parse(Console.ReadLine());
            double grapesPerSqM = double.Parse(Console.ReadLine());
            int wineForSell = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double grapesHarvest = vineyardSqM * grapesPerSqM;
            double wineMadeTotal = 0.4*grapesHarvest / 2.5;

            if (wineMadeTotal < wineForSell)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(wineForSell-wineMadeTotal)} liters wine needed.");
            }
            else
            {
                double wineLeft = Math.Ceiling(wineMadeTotal - wineForSell);
                double winePerWorker = Math.Ceiling(wineLeft / workers);
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wineMadeTotal)} liters.");
                Console.WriteLine($"{wineLeft} liters left -> {winePerWorker} liters per person.");
            }
        }
    }
}
