using System;

namespace Bills
{
    class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());

            double electricityTotal = 0;
            double waterTotal = months * 20;
            double internetTotal = months * 15;
            double othersTotal = 0;

            for (int counter = 1; counter <=months; counter++)
            {
                double electricity = double.Parse(Console.ReadLine());
                electricityTotal += electricity;
                othersTotal += (electricity + 20 + 15) * 1.2;
            }

            double average = (electricityTotal + waterTotal + internetTotal + othersTotal) / months;

            Console.WriteLine($"Electricity: {electricityTotal:F2} lv");
            Console.WriteLine($"Water: {waterTotal:F2} lv");
            Console.WriteLine($"Internet: {internetTotal:F2} lv");
            Console.WriteLine($"Other: {othersTotal:F2} lv");
            Console.WriteLine($"Average: {average:F2} lv");

        }
    }
}
