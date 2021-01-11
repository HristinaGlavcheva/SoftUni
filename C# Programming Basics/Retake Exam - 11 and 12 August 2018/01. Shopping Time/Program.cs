using System;

namespace _01._Shopping_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            int freeTime = int.Parse(Console.ReadLine());
            double peripheralDevicePrice = double.Parse(Console.ReadLine());
            double programPrice = double.Parse(Console.ReadLine());
            double coffeePrice = double.Parse(Console.ReadLine());

            double sumForPeriperalDevices = peripheralDevicePrice * 3;
            double sumForPrograms = programPrice * 2;
            double totalSum = sumForPeriperalDevices + sumForPrograms + coffeePrice;
            int timeForRealax = freeTime - 3 * 2 - 2 * 2 - 5;

            Console.WriteLine($"{totalSum:F2}");
            Console.WriteLine(timeForRealax);
        }
    }
}
