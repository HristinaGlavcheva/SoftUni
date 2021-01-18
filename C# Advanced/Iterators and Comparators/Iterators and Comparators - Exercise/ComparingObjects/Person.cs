using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ComparingObjects 
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
            this.CountEquel = 1;
        }

        public string Name { get; }

        public int Age { get; }

        public string Town { get; }

        public int CountEquel { get; private set; }

        public int CompareTo(Person other)
        {
            int result = this.Name.CompareTo(other.Name);

            if(result == 0)
            {
                result = this.Age.CompareTo(other.Age);

                if(result == 0)
                {
                    result = this.Town.CompareTo(other.Town);

                    if(result == 0)
                    {
                        this.CountEquel++;
                    }
                }
            }

            return result;
        }
    }
}
