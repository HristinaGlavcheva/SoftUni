using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List <Person> allPeople = new List<Person>();

            string input = Console.ReadLine();            

            while(input != "END")
            {
                string[] personData = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                int age = int.Parse(personData[1]);
                string town = personData[2];

                Person currentPerson = new Person(name, age, town);

                allPeople.Add(currentPerson);

                input = Console.ReadLine();
            }

            int personNumber = int.Parse(Console.ReadLine());
            int personIndex = personNumber - 1;

            for (int i = 0; i < personIndex; i++)
            {
                allPeople[personIndex].CompareTo(allPeople[i]);
            }

            for (int i = personIndex + 1; i < allPeople.Count; i++)
            {
                allPeople[personIndex].CompareTo(allPeople[i]);
            }

            int countOfMatches = allPeople[personIndex].CountEquel;
            int totalNumberOfPeople = allPeople.Count;
            int numberNotEquelPeople = totalNumberOfPeople - countOfMatches;

            if(countOfMatches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countOfMatches} {numberNotEquelPeople} {totalNumberOfPeople}");
            }
        }
    }
}
