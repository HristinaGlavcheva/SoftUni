using System;

namespace _04._Easter_Eggs_Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            int countEggsFirstPlayer = int.Parse(Console.ReadLine());
            int countEggsSecondPlayer = int.Parse(Console.ReadLine());
            string winner = Console.ReadLine();

            while (winner != "End of battle")
            {
                if (winner == "one")
                {
                    countEggsSecondPlayer--;
                    if (countEggsSecondPlayer == 0)
                    {
                        break;
                    }
                }
                else if (winner == "two")
                {
                    countEggsFirstPlayer--;
                    if (countEggsFirstPlayer == 0)
                    {
                        break;
                    }
                }
                winner = Console.ReadLine();
            }

            if (countEggsFirstPlayer == 0)
            {
                Console.WriteLine($"Player one is out of eggs. Player two has {countEggsSecondPlayer} eggs left.");
            }
            else if (countEggsSecondPlayer == 0)
            {
                Console.WriteLine($"Player two is out of eggs. Player one has {countEggsFirstPlayer} eggs left.");
            }
            if (winner == "End of battle")
            {
                Console.WriteLine($"Player one has {countEggsFirstPlayer} eggs left.");
                Console.WriteLine($"Player two has {countEggsSecondPlayer} eggs left.");
            }
        }
        
    }
}
