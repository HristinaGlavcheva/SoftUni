using System;

namespace Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N1 = int.Parse(Console.ReadLine());
            int N2 = int.Parse(Console.ReadLine());
            char action=char.Parse(Console.ReadLine());
            double result=0;
            string type = "";

           if (action == '+')
            {
                result = N1 + N2;
            }
           else if (action == '-')
            {
                result = N1 - N2;
            }
            else if (action == '*')
            {
                result = N1 * N2;
            }
            else if (action == '/' && N2!=0)
            {
                result = N1*1.0 / N2 ;
            }
            else if (action == '%' && N2 != 0)
            {
                result = N1 % N2;
            }

            if ((action == '+' || action == '-' || action == '*') && result % 2==0)
            {
                type = "even";
            }
            else 
            {
                type = "odd";
            }

            if (action == '+' || action == '-' || action == '*')
            {
                Console.WriteLine($"{N1} {action} {N2} = {result} - {type}");
            }
            else if ((action == '/') && N2!=0)
            {
                Console.WriteLine($"{N1} {action} {N2} = {result:F2}");
            }
            else if ((action == '%') && N2 != 0)
            {
                Console.WriteLine($"{N1} {action} {N2} = {result}");
            }
            else if ((action == '/' || action == '%') && N2 == 0)
            {
                Console.WriteLine($"Cannot divide {N1} by zero");
            }

        }
    }
}
