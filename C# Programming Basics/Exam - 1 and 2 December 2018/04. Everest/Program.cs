using System;

namespace _04._Everest
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int countDays = 1;
            int metersClimbed = 5364;

            while (command != "END")
            {
                int currentDistance = int.Parse(Console.ReadLine());
                if (command == "Yes")
                {
                    countDays++;
                }
                if (countDays > 5)
                {
                    break;
                }
                metersClimbed += currentDistance;
                if(metersClimbed >= 8848)
                {
                    break;
                }
                command = Console.ReadLine();
            }

            if (metersClimbed >= 8848)
            {
                Console.WriteLine($"Goal reached for {countDays} days!");
            }
            else
            {
                Console.WriteLine("Failed!");
                Console.WriteLine($"{metersClimbed}");
            }
            
        }
    }
}
