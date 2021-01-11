using System;

namespace Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());
            double volumeLitresTotal= lenght * width * height * 0.001;
            double waterNeeded = volumeLitresTotal * (100 - percent) * 0.01;
            Console.WriteLine($"{waterNeeded:F3}");
        }
    }
}
