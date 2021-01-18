using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> guestsList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] commandArgs = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<string> filters = new List<string>();

            while (commandArgs[0] != "Print")
            {
                string command = commandArgs[0];

                if (command == "Add filter")
                {
                    filters.Add($"{commandArgs[1]};{commandArgs[2]}");
                }
                else if (command == "Remove filter")
                {
                    filters.Remove($"{commandArgs[1]};{commandArgs[2]}");
                }

                commandArgs = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var filter in filters)
            {
                string[] filterInfo = filter.Split(";");
                
                Predicate<string> predicate = GetPredicate(filterInfo);

                guestsList.RemoveAll(predicate);
            }

            Console.WriteLine(String.Join(" ", guestsList));
        }

        static Predicate<string> GetPredicate(string[] filterInfo)
        {
            string filterType = filterInfo[0];
            string filterParameter = filterInfo[1];

            Predicate<string> predicate = null;

            if(filterType == "Starts with")
            {
                predicate = n => n.StartsWith(filterParameter);
            }
            else if (filterType == "Ends with")
            {
                predicate = n => n.EndsWith(filterParameter);
            }
            else if (filterType == "Length")
            {
                predicate = n => n.Length == int.Parse(filterParameter);
            }
            else if (filterType == "Contains")
            {
                predicate = n => n.Contains(filterParameter);
            }

            return predicate;
        }
    }
}
