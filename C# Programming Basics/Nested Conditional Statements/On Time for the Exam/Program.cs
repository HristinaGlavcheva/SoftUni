using System;

namespace On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHours = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHours = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            int examTimeInMinutes = examHours * 60 + examMinutes;
            int arrivalTimeInMinutes = arrivalHours * 60 + arrivalMinutes;
            int marginTimes = examTimeInMinutes - arrivalTimeInMinutes;

            if ((marginTimes) > 30)
            {
                Console.WriteLine("Early");
            }
            else if ((marginTimes) >= 0 && (marginTimes) <= 30)
            {
                Console.WriteLine("On time");
            }
            else
            {
                Console.WriteLine("Late");
            }

            if (marginTimes != 0)
            {
                if (marginTimes >= 60 )
                {
                    if (marginTimes % 60 >= 10)
                    {
                        Console.WriteLine($"{marginTimes / 60}:{marginTimes % 60} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{marginTimes / 60}:0{marginTimes % 60} hours before the start");
                    }
                }

                else if (marginTimes > 0 && marginTimes < 60)
                {
                    Console.WriteLine($"{marginTimes % 60} minutes before the start");
                }
                
                else if (marginTimes < 0 && marginTimes > -60)
                {
                    Console.WriteLine($"{-marginTimes % 60} minutes after the start");
                }

                else if (marginTimes <= -60)
                {
                    if (marginTimes % 60 <= -10)
                    {
                        Console.WriteLine($"{-marginTimes / 60}:{-marginTimes % 60} hours after the start");
                    }
                    else 
                    {
                        Console.WriteLine($"{-marginTimes / 60}:0{-marginTimes % 60} hours after the start");
                    }
                }
            }
        }
    }
}
