using System;

namespace _01._Trekking_equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int countClimbers = int.Parse(Console.ReadLine());
            int countCarabineers = int.Parse(Console.ReadLine());
            int countRopes = int.Parse(Console.ReadLine());
            int countIcePicks = int.Parse(Console.ReadLine());

            double sumForOneClimber = countCarabineers * 36 + countRopes * 3.60 + countIcePicks * 19.80;
            double sumForAllClimbers = sumForOneClimber * countClimbers;
            double finalSum = sumForAllClimbers * 1.2;

            Console.WriteLine($"{finalSum:F2}");
        }
    }
}
