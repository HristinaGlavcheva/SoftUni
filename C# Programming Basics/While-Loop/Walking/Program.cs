using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsTotal = 0;
            string command = string.Empty;

            while (stepsTotal < 10000)
            {
                 command = Console.ReadLine();

                if (command == "Going home")
                {
                    int currentSteps = int.Parse(Console.ReadLine());
                    stepsTotal += currentSteps;

                    if (stepsTotal >= 10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{10000 - stepsTotal} more steps to reach goal.");
                        break;
                    }
                }

                else
                {
                    int currentSteps = int.Parse(command);
                    stepsTotal += currentSteps;

                    if (stepsTotal >= 10000)
                    {
                        Console.WriteLine("Goal reached! Good job!");
                        break;
                    }
                }
                    
            }
        }
    }
}
