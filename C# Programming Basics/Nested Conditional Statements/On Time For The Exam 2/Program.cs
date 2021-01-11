using System;

namespace On_Time_For_The_Exam_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arriveHour = int.Parse(Console.ReadLine());
            int arriveMinutes = int.Parse(Console.ReadLine());

            int examTimeInMinutes = examHour * 60 + examMinutes;
            int arriveTimeInMinutes = arriveHour * 60 + arriveMinutes;
            int diffInMinutes = examTimeInMinutes - arriveTimeInMinutes;

            if (diffInMinutes <= 30 && diffInMinutes >= 0)
            {
                Console.WriteLine("On time");
                if (diffInMinutes != 0)
                {
                    Console.WriteLine($"{diffInMinutes} minutes before the start");
                }
            }
            else if (diffInMinutes > 30)
            {
                Console.WriteLine("Early");
                if (diffInMinutes < 60)
                {
                    Console.WriteLine($"{diffInMinutes} minutes before the start");
                }
                else
                {
                    int hoursEarly= diffInMinutes / 60;
                    int minutesEarly = diffInMinutes % 60;
                    Console.WriteLine($"{hoursEarly}:{minutesEarly:D2} hours before the start");
                }
            }
            else if (diffInMinutes < 0)
            {
                Console.WriteLine("Late");
                if (diffInMinutes > -60)
                {
                    Console.WriteLine($"{-diffInMinutes} minutes after the start");
                }
                else
                {
                    int hoursLate = -diffInMinutes / 60;
                    int minutesLate = -diffInMinutes % 60;
                    Console.WriteLine($"{hoursLate}:{minutesLate:D2} hours after the start");
                }
            }
        }
    }
}
