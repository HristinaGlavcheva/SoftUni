using System;

namespace Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int countLoads = int.Parse(Console.ReadLine());
            double totalPrice = 0;
            int totalWeight = 0;
            int tonsMinibus = 0;
            int tonsTruck = 0;
            int tonsTrain = 0;

            for (int i = 1; i <= countLoads; i++)
            {
                int weight = int.Parse(Console.ReadLine());
                totalWeight += weight;

                if (weight <= 3)
                {
                    totalPrice += weight * 200;
                    tonsMinibus += weight;
                }
                else if (weight >= 4 && weight <= 11)
                {
                    totalPrice += weight * 175;
                    tonsTruck += weight;
                }
                else
                {
                    totalPrice += weight * 120;
                    tonsTrain += weight;
                }
            }

            double averagePrice = totalPrice / totalWeight;

            Console.WriteLine($"{averagePrice:F2}");
            Console.WriteLine($"{(tonsMinibus*1.0/totalWeight*100):F2}%");
            Console.WriteLine($"{(tonsTruck*1.0/totalWeight*100):F2}%");
            Console.WriteLine($"{(tonsTrain*1.0/totalWeight*100):F2}%");
        }
    }
}
