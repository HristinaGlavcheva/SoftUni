using System;

namespace _05._Fitness_Center
{
    class Program
    {
        static void Main(string[] args)
        {
            int couontVisitors = int.Parse(Console.ReadLine());
            int back = 0;
            int chest = 0;
            int legs = 0;
            int abs = 0;
            int proteinBar = 0;
            int proteinShake = 0;

            for (int currentVisitor = 1; currentVisitor <= couontVisitors; currentVisitor++)
            {
                string actoion = Console.ReadLine();

                if (actoion == "Back")
                {
                    back++;
                }
                else if (actoion == "Chest")
                {
                    chest++;
                }
                else if (actoion == "Legs")
                {
                    legs++;
                }
                else if (actoion == "Abs")
                {
                    abs++;
                }
                else if (actoion == "Protein shake")
                {
                    proteinShake++;
                }
                else if (actoion == "Protein bar")
                {
                    proteinBar++;
                }
            }
            double percentWorkOut = (back + chest + legs + abs)*1.0 / couontVisitors * 100;
            double percentProtein = (proteinBar + proteinShake) * 1.0 / couontVisitors * 100;

            Console.WriteLine($"{back} - back");
            Console.WriteLine($"{chest} - chest");
            Console.WriteLine($"{legs} - legs");
            Console.WriteLine($"{abs} - abs");
            Console.WriteLine($"{proteinShake} - protein shake");
            Console.WriteLine($"{proteinBar} - protein bar");
            Console.WriteLine($"{percentWorkOut:F2}% - work out");
            Console.WriteLine($"{percentProtein:F2}% - protein");
        }
    }
}
