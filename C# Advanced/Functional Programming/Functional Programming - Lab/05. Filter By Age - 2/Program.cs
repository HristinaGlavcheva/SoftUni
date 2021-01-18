using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countPeople = int.Parse(Console.ReadLine());

            List<KeyValuePair<string, int>> people = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < countPeople; i++)
            {
                string[] curPersonInfo = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = curPersonInfo[0];
                int age = int.Parse(curPersonInfo[1]);

                people.Add(new KeyValuePair<string, int>(name, age));
            }

            string filterCondition = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());
            string printFormat = Console.ReadLine();

            
        }
    }
}

