using System;

namespace Person
{
    public class Person
    {
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; }

        public virtual int Age
        {
            get 
            {
                return this.age; 
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age can not be a negative number;");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
