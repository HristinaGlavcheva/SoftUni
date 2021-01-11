using System;

namespace Exam_Preparetion
{
    class Program
    {
        static void Main(string[] args)
        {
            int countSectors = int.Parse(Console.ReadLine());
            int stadiumCapacity = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());

            double totalIncome = stadiumCapacity * ticketPrice;
            double incomeForSector = totalIncome / countSectors;
            double moneyForCharity = (totalIncome - 0.75 * incomeForSector) / 8;

            Console.WriteLine($"Total income - {totalIncome:F2} BGN");
            Console.WriteLine($"Money for charity - {moneyForCharity:F2} BGN");
            
        }
    }
}
