using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialGreenSeconds = int.Parse(Console.ReadLine());
            int yellowSeconds = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            int passedCars = 0;
            Queue<string> waitingCars = new Queue<string>();

            while (command != "END")
            {
                if (command != "green")
                {
                    waitingCars.Enqueue(command);
                }
                else
                {
                    int greenSeconds = initialGreenSeconds;

                    while (waitingCars.Any() && greenSeconds > 0)
                    {
                        if (greenSeconds >= waitingCars.Peek().Length)
                        {
                            passedCars++;
                            greenSeconds -= waitingCars.Peek().Length;
                            waitingCars.Dequeue();
                        }
                        else if (greenSeconds + yellowSeconds >= waitingCars.Peek().Length)
                        {
                            passedCars++;
                            waitingCars.Dequeue();
                            break;
                        }
                        else if (greenSeconds + yellowSeconds < waitingCars.Peek().Length)
                        {
                            Console.WriteLine("A crash happened!");
                            int index = greenSeconds + yellowSeconds;
                            Console.WriteLine($"{waitingCars.Peek()} was hit at {waitingCars.Peek()[index]}.");
                            return;
                        }

                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}