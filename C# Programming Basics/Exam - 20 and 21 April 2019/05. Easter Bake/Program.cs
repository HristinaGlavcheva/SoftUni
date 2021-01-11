using System;

namespace _05._Easter_Bake
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalEasterBreads = int.Parse(Console.ReadLine());
            int totalSugarGrams = 0;
            int totalFlourGrams = 0;
            int sugarMax = 0;
            int flourMax = 0;

            for (int countEasterBreads=1; countEasterBreads<=totalEasterBreads; countEasterBreads++)
            {
                int sugarNeededGrams = int.Parse(Console.ReadLine());
                int flourNeededGrams = int.Parse(Console.ReadLine());
                totalSugarGrams += sugarNeededGrams;
                totalFlourGrams += flourNeededGrams;

                if (sugarNeededGrams > sugarMax)
                {
                    sugarMax = sugarNeededGrams;
                }
                if (flourNeededGrams > flourMax)
                {
                    flourMax = flourNeededGrams;
                }
            }

            double sugarNeededPackages = Math.Ceiling(totalSugarGrams*1.0 / 950);
            double flourNeededPackages = Math.Ceiling(totalFlourGrams * 1.0 / 750);

            Console.WriteLine($"Sugar: {sugarNeededPackages}");
            Console.WriteLine($"Flour: {flourNeededPackages}");
            Console.WriteLine($"Max used flour is {flourMax} grams, max used sugar is {sugarMax} grams.");
        }
    }
}
