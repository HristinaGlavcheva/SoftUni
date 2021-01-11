using System;

namespace Time_15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            

            if (minutes < 45)
            {
                minutes = minutes + 15;
            }
            else
            {
                minutes = minutes + 15 - 60;
                if (hours < 23)
                {
                    hours = hours + 1;
                }
                else
                {
                    hours = 0;
                }
            }

            if (minutes < 10)
            {
                Console.WriteLine($"{hours}:0{minutes}");
            }
            else
            {
                Console.WriteLine($"{hours}:{minutes}");
            }
        }
    }
}
