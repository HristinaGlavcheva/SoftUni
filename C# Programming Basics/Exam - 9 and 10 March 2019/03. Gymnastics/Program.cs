using System;

namespace _03._Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string appliance = Console.ReadLine();
            double grade = 0;

            if(country == "Russia")
            {
                if(appliance == "ribbon")
                {
                    grade = 9.100 + 9.400;
                }
                else if(appliance == "hoop")
                {
                    grade = 9.300 + 9.800;
                }
                else if (appliance == "rope")
                {
                    grade = 9.600 + 9.000;
                }
            }
            else if (country == "Bulgaria")
            {
                if (appliance == "ribbon")
                {
                    grade = 9.600 + 9.400;
                }
                else if (appliance == "hoop")
                {
                    grade = 9.550 + 9.750;
                }
                else if (appliance == "rope")
                {
                    grade = 9.500 + 9.400;
                }
            }
            else if (country == "Italy")
            {
                if (appliance == "ribbon")
                {
                    grade = 9.200 + 9.500;
                }
                else if (appliance == "hoop")
                {
                    grade = 9.450 + 9.350;
                }
                else if (appliance == "rope")
                {
                    grade = 9.700 + 9.150;
                }
            }
            double percentNeeded = (20 - grade) / 20 * 100;
            Console.WriteLine($"The team of {country} get {grade:F3} on {appliance}.");
            Console.WriteLine($"{percentNeeded:F2}%");
        }
    }
}
