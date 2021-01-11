using System;

namespace _08._Secret_Door_s_Lock
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxHundreds = int.Parse(Console.ReadLine());
            int maxTens = int.Parse(Console.ReadLine());
            int maxUnits = int.Parse(Console.ReadLine());

            for (int hundreds = 1; hundreds <= maxHundreds; hundreds++)
            {
                for (int tens = 1; tens <= maxTens; tens++)
                {
                    for (int units = 1; units <= maxUnits; units++)
                    {
                        bool condition1 = hundreds % 2 == 0;
                        bool condition2 = units % 2 == 0;
                        bool condition3 = tens == 2 || tens == 3 || tens == 5 || tens == 7;
                        if (condition1 && condition2 && condition3)
                        {
                            Console.WriteLine($"{hundreds} {tens} {units}");
                        }
                    }
                }
            }
        }
    }
}
