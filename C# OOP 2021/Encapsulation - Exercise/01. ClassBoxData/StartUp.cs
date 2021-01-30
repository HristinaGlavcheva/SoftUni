using System;

namespace _01._ClassBoxData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);

                Console.WriteLine($"{box.CalculateSurfaceArea():F2}");
                Console.WriteLine($"{box.CalculateLateralSurfaceArea():F2}");
                Console.WriteLine($"{box.CalculateVolume():F2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
