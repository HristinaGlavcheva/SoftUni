using System;

namespace Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            double changeInSt = Math.Floor(change * 100);
            double countCoins = 0;

            while (changeInSt > 0)
            {
                if (changeInSt >= 200)
                {
                    countCoins++;
                    changeInSt = changeInSt - 200;
                }
                else if (changeInSt >= 100)
                {
                    countCoins++;
                    changeInSt = changeInSt - 100;
                }
                else if (changeInSt >= 50)
                {
                    countCoins++;
                    changeInSt = changeInSt - 50;
                }
                else if (changeInSt >= 20)
                {
                    countCoins++;
                    changeInSt -= 20;
                }
                else if (changeInSt >= 10)
                {
                    countCoins++;
                    changeInSt -= 10;
                }
                else if (changeInSt >= 5)
                {
                    countCoins++;
                    changeInSt -= 5;
                }
                else if (changeInSt >= 2)
                {
                    countCoins++;
                    changeInSt -= 2;
                }
                else if (changeInSt >= 1)
                {
                    countCoins++;
                    changeInSt -= 1;
                }
            }

            Console.WriteLine(countCoins);
        }
    }
}
