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

            List<KeyValuePair<string, int>> peopleInfo = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < countPeople; i++)
            {
                string[] curPersonInfo = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = curPersonInfo[0];
                int age = int.Parse(curPersonInfo[1]);

                peopleInfo.Add(new KeyValuePair<string, int>(name, age));
            }

            string filterCondition = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());
            string printFormat = Console.ReadLine();

            //Func<KeyValuePair<string, int>, bool> filterFunc = peopleInfo => true;

            //if (filterCondition == "older")
            //{
            //    filterFunc = p => p.Value >= filterAge;
            //}
            //else if (filterCondition == "younger")
            //{
            //    filterFunc = p => p.Value < filterAge;
            //}

            //peopleInfo = peopleInfo.Where(filterFunc).ToList();

            Func<KeyValuePair<string, int>, bool> filterFunc = filterCondition switch
            {
                "older" => p => p.Value >= filterAge,
                "younger" => p => p.Value < filterAge,
                _ => null,
            };

            //Func<KeyValuePair<string, int>, string> printFunc = peopleInfo => null;

            //if(printFormat == "name age")
            //{
            //    printFunc = p => $"{p.Key} - {p.Value}";
            //}
            //else if(printFormat == "name")
            //{
            //    printFunc = p => $"{p.Key}";
            //}
            //else if (printFormat == "age")
            //{
            //    printFunc = p => $"{p.Value}";
            //}

            Func<KeyValuePair<string, int>, string> printFunc = printFormat switch
            {
                "name age" => p => $"{p.Key} - {p.Value}",
                "name" => p => p.Key,
                "age" => p => p.Value.ToString(),
                _ => null
            };

            peopleInfo
                .Where(filterFunc)
                .Select(printFunc)
                .ToList()
                .ForEach(Console.WriteLine);

        }
    }
}

