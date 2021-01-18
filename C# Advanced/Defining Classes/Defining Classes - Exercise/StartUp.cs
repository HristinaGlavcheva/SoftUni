using System;

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

            Person oldestPerson = family.GetOldestMember();

            Console.WriteLine(oldestPerson);



            //Problem 01.Define a Class Person:

            //Person firstPerson = new Person();

            //firstPerson.Name = "Pesho";
            //firstPerson.Age = 20;

            //Person secondPerson = new Person()
            //{
            //    Name = "Gosho",
            //    Age = 18
            //};

            //Person thirdPerson = new Person("Stamat", 43);

            //--------------------------------------------------

            //Problem 02. Creating Constructors:

            //Person somePerson = new Person("Ivan", 25);

            //Person other = new Person(36);

            //Person anybody = new Person();

            //Console.WriteLine($"{anybody.Name}, {anybody.Age}");
            //Console.WriteLine($"{other.Name}, {other.Age}");
            //Console.WriteLine($"{somePerson.Name}, {somePerson.Age}");
        }
    }
}
