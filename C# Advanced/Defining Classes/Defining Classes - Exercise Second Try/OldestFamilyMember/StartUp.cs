using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Family family = new Family();

            int countMembers = int.Parse(Console.ReadLine());

            for (int i = 0; i < countMembers; i++)
            {
                string[] memberInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = memberInfo[0];
                int age = int.Parse(memberInfo[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }

            Person oldestMember = family.GetOldestMember();

            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}
