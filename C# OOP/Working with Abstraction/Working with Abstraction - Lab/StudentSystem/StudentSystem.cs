using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem
{
    public class StudentSystem
    {
        public Dictionary<string, Student> StudentsInfo { get; } = new Dictionary<string, Student>();

        public void AddStudent(string name, int age, double grade)
        {
            if (!this.StudentsInfo.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                this.StudentsInfo[name] = student;
            }
        }

        public string ShowStudentInfo(string name)
        {
            if (!StudentsInfo.ContainsKey(name))
            {
                return null;
            }

            var student = this.StudentsInfo[name];

            StringBuilder sb = new StringBuilder();

            sb.Append($"{student.Name} is {student.Age} years old.");

            if (student.Grade >= 5.00)
            {
                sb.Append(" Excellent student.");
            }
            else if (student.Grade < 5.00 && student.Grade >= 3.50)
            {
                sb.Append(" Average student.");
            }
            else
            {
                sb.Append(" Very nice person.");
            }

            return sb.ToString().TrimEnd();
        }

        public void ParseCommand()
        {
            string[] args = Console.ReadLine().Split();

            var command = args[0];
           

            if (command == "Create")
            {
                var name = args[1];
                var age = int.Parse(args[2]);
                var grade = double.Parse(args[3]);

                this.AddStudent(name, age, grade);
            }
            else if (command == "Show")
            {
                var name = args[1];

                var studentInfo = this.ShowStudentInfo(name);
               
                Console.WriteLine(studentInfo);
             }
            else if (command == "Exit")
            {
                Environment.Exit(0);
            }
        }
    }
}
