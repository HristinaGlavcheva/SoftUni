using System;

namespace _05._Project_Prize
{
    class Program
    {
        static void Main(string[] args)
        {
            int countParts = int.Parse(Console.ReadLine());
            double prizePerPoint = double.Parse(Console.ReadLine());
            int sumPoints = 0;

            for (int currentPart = 1; currentPart <= countParts; currentPart++)
            {
                int currentPoints = int.Parse(Console.ReadLine());
                if (currentPart % 2 == 0)
                {
                    sumPoints += 2 * currentPoints;
                }
                else
                {
                    sumPoints += currentPoints;
                }
            }
            double totalPrize = prizePerPoint * sumPoints;
            Console.WriteLine($"The project prize was {totalPrize:F2} lv.");
        }
    }
}
