using System;

namespace _05._Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int countGroups = int.Parse(Console.ReadLine());
            int countClimbersMusala = 0;
            int countClimbersMontBlank = 0;
            int countClimbersKilimanjaro = 0;
            int countClimbersK2 = 0;
            int countClimbersEverest = 0;
            int totalCountClimbers = 0;

            for (int currentGroup = 1; currentGroup <= countGroups; currentGroup++)
            {
                int currentCoutClimbers = int.Parse(Console.ReadLine());
                totalCountClimbers += currentCoutClimbers;

                if(currentCoutClimbers  <= 5)
                {
                    countClimbersMusala += currentCoutClimbers;
                }
                else if(currentCoutClimbers >=6 && currentCoutClimbers <= 12)
                {
                    countClimbersMontBlank += currentCoutClimbers;
                }
                else if (currentCoutClimbers >= 12 && currentCoutClimbers <= 25)
                {
                    countClimbersKilimanjaro += currentCoutClimbers;
                }
                else if (currentCoutClimbers >= 26 && currentCoutClimbers <= 40)
                {
                    countClimbersK2 += currentCoutClimbers;
                }
                else 
                {
                    countClimbersEverest += currentCoutClimbers;
                }
            }

            double percentClimbersMusala = countClimbersMusala * 1.0 / totalCountClimbers * 100;
            double percentClimbersMontBlank = countClimbersMontBlank * 1.0 / totalCountClimbers * 100;
            double percentClimbersKilimanjaro = countClimbersKilimanjaro * 1.0 / totalCountClimbers * 100;
            double percentClimbersK2 = countClimbersK2 * 1.0 / totalCountClimbers * 100;
            double percentClimbersEverest = countClimbersEverest * 1.0 / totalCountClimbers * 100;

            Console.WriteLine($"{percentClimbersMusala:F2}%");
            Console.WriteLine($"{percentClimbersMontBlank:F2}%");
            Console.WriteLine($"{percentClimbersKilimanjaro:F2}%");
            Console.WriteLine($"{percentClimbersK2:F2}%");
            Console.WriteLine($"{percentClimbersEverest:F2}%");
        }
    }
}
