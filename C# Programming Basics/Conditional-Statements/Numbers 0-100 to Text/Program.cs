using System;

namespace Numbers_0_100_to_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string firstDigit="";
            string secondDigit="";

            if (number == 0)
            {
                Console.WriteLine("zero");
            }
            else if (number == 1)
            {
                Console.WriteLine("one");
            }
            else if (number == 2)
            {
                Console.WriteLine("two");
            }
            else if (number == 3)
            {
                Console.WriteLine("three");
            }
            else if (number == 4)
            {
                Console.WriteLine("four");
            }
            else if (number == 5)
            {
                Console.WriteLine("five");
            }
            else if (number == 6)
            {
                Console.WriteLine("six");
            }
            else if (number == 7)
            {
                Console.WriteLine("seven");
            }
            else if (number == 8)
            {
                Console.WriteLine("eight");
            }
            else if (number == 9)
            {
                Console.WriteLine("nine");
            }
            else if (number == 10)
            {
                Console.WriteLine("ten");
            }
            else if (number == 11)
            {
                Console.WriteLine("eleven");
            }
            else if (number == 12)
            {
                Console.WriteLine("twelve");
            }
            else if (number == 13)
            {
                Console.WriteLine("thirteen");
            }
            else if (number == 14)
            {
                Console.WriteLine("fourteen");
            }
            else if (number == 15)
            {
                Console.WriteLine("fifteen");
            }
            else if (number == 16)
            {
                Console.WriteLine("sixteen");
            }
            else if (number == 17)
            {
                Console.WriteLine("seventeen");
            }
            else if (number == 18)
            {
                Console.WriteLine("eighteen");
            }
            else if (number == 19)
            {
                Console.WriteLine("nineteen");
            }

            if (number / 10 == 2)
            {
                firstDigit = "twenty";
            }
            else if (number / 10 == 3)
            {
                firstDigit = "thirty";
            }
            else if (number / 10 == 4)
            {
                firstDigit = "forty";
            }
            else if (number / 10 == 5)
            {
                firstDigit = "fifty";
            }
            else if (number / 10 == 6)
            {
                firstDigit = "sixty";
            }
            else if (number / 10 == 7)
            {
                firstDigit = "seventy";
            }
            else if (number / 10 == 8)
            {
                firstDigit = "eighty";
            }
            else if (number / 10 == 9)
            {
                firstDigit = "ninety";
            }
            else if (number / 10 == 10)
            {
                firstDigit = "one hundred";
            }


            if (number % 10 == 1)
            {
                secondDigit = "one";
            }
            else if (number % 10 == 2)
            {
                secondDigit = "two";
            }
            else if (number % 10 == 3)
            {
                secondDigit = "three";
            }
            else if (number % 10 == 4)
            {
                secondDigit = "four";
            }
            else if (number % 10 == 5)
            {
                secondDigit = "five";
            }
            else if (number % 10 == 6)
            {
                secondDigit = "six";
            }
            else if (number % 10 == 7)
            {
                secondDigit = "seven";
            }
            else if (number % 10 == 8)
            {
                secondDigit = "eight";
            }
            else if (number % 10 == 9)
            {
                secondDigit = "nine";
            }
            else
            {
                secondDigit = "";
            }

            if (number > 19)
            {
                Console.WriteLine(firstDigit + " " + secondDigit);
            }
        }
    }
}
