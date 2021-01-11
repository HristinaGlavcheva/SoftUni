using System;

namespace _04._Game_Number_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstPlayerName = Console.ReadLine();
            string secondPlayerName = Console.ReadLine();
            string command = Console.ReadLine();
            int firstPlayerPoints = 0;
            int secondPlayerPoints = 0;
            string winnerName = string.Empty;
            int winnerPoints = 0;

            while (command != "End of game")
            {
                int firstPlayerCard = int.Parse(command);
                int secondPlayerCard = int.Parse(Console.ReadLine());
                if(firstPlayerCard > secondPlayerCard)
                {
                    firstPlayerPoints += firstPlayerCard - secondPlayerCard;
                }
                else if (secondPlayerCard > firstPlayerCard)
                {
                    secondPlayerPoints += secondPlayerCard - firstPlayerCard;
                }
                else
                {
                    Console.WriteLine("Number wars!");
                    firstPlayerCard = int.Parse(Console.ReadLine());
                    secondPlayerCard = int.Parse(Console.ReadLine());
                    if (firstPlayerCard > secondPlayerCard)
                    {
                        winnerName = firstPlayerName;
                        winnerPoints = firstPlayerPoints;
                    }
                    else if (secondPlayerCard > firstPlayerCard)
                    {
                        winnerName = secondPlayerName;
                        winnerPoints = secondPlayerPoints;
                    }
                    
                    Console.WriteLine($"{winnerName} is winner with {winnerPoints} points");
                    return;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{firstPlayerName} has {firstPlayerPoints} points");
            Console.WriteLine($"{secondPlayerName} has {secondPlayerPoints} points");
        }
    }
}
