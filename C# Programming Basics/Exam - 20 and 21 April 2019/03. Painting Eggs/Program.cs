using System;

namespace _03._Painting_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string size = Console.ReadLine();
            string colour = Console.ReadLine();
            int countBatches = int.Parse(Console.ReadLine());
            int pricePerBatch = 0;

            if (size == "Large")
            {
                if (colour == "Red")
                {
                    pricePerBatch = 16;
                }
                else if (colour == "Green")
                {
                    pricePerBatch = 12;
                }
                else if (colour == "Yellow")
                {
                    pricePerBatch = 9;
                }
            }
            else if (size == "Medium")
            {
                if (colour == "Red")
                {
                    pricePerBatch = 13;
                }
                else if (colour == "Green")
                {
                    pricePerBatch = 9;
                }
                else if (colour == "Yellow")
                {
                    pricePerBatch = 7;
                }
            }
            else if (size == "Small")
            {
                if (colour == "Red")
                {
                    pricePerBatch = 9;
                }
                else if (colour == "Green")
                {
                    pricePerBatch = 8;
                }
                else if (colour == "Yellow")
                {
                    pricePerBatch = 5;
                }
            }

            double totalIncome = countBatches * pricePerBatch;
            double costs = totalIncome * 0.35;
            double finalIncome = totalIncome - costs;

            Console.WriteLine($"{finalIncome:F2} leva.");
        }
    }
}
