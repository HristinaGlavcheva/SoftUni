using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int countPeople = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < countPeople; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name,age);

                people.Add(person);
            }

            foreach (var person in people.Where(p => p.Age > 30).OrderBy(p => p.Name))
            {
                Console.WriteLine(person);
            }
        }
    }
}
