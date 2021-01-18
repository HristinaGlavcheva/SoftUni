using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);


            while (command[0] != "Party!")
            {
                string action = command[0];

                Predicate<string> predicate = GetPredicate(command);

                if (action == "Remove")
                {
                    guests.RemoveAll(predicate);
                }
                else if (action == "Double")
                {
                    DoubleGuest(guests, predicate);
                }

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"{String.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void DoubleGuest(List<string> guests, Predicate<string> predicate)
        {
            for (int i = 0; i < guests.Count; i++)
            {
                string currGuest = guests[i];

                if (predicate(currGuest))
                {
                    guests.Insert(i + 1, currGuest);
                    i++;
                }
            }
        }

        static Predicate<string> GetPredicate(string[] command)
        {
            string criteria = command[1];
            string criteriaSubject = command[2];

            Predicate<string> predicate = null; ;

            if (criteria == "StartsWith")
            {
                predicate = n => n.StartsWith(criteriaSubject);
            }
            else if (criteria == "EndsWith")
            {
                predicate = n => n.EndsWith(criteriaSubject);
            }
            else if (criteria == "Length")
            {
                predicate = n => n.Length == int.Parse(criteriaSubject);
            }

            return predicate;
        }
    }
}
