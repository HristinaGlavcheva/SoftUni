using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int countMembers = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < countMembers; i++)
            {
                string[] curMemberInfo = Console.ReadLine()
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = curMemberInfo[0];
                int age = int.Parse(curMemberInfo[1]);

                Person curPerson = new Person(name, age);

                family.AddMember(curPerson);
            }

            HashSet<Person> peopleAboveThirty = family.GetOlderTnahThirty();

            Console.WriteLine(String.Join(Environment.NewLine, peopleAboveThirty));
        }
    }
}
