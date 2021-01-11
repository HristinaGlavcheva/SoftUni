using System;

namespace Salary
{
    class Program
    {
        static void Main(string[] args)
        {
            int countTabs = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            for (int i = 1; i <= countTabs; i++)
            {
                string nameTab = Console.ReadLine();

                if (nameTab == "Facebook")
                {
                    salary -= 150;
                }
                else if (nameTab == "Instagram")
                {
                    salary -= 100;
                }
                else if (nameTab == "Reddit")
                {
                    salary -= 50;
                }
                if (salary <= 0)
                {
                    Console.WriteLine("You have lost your salary.");
                    break;
                }
            }

            if (salary > 0)
            {
                Console.WriteLine((int)salary);
            }
        }
    }
}
