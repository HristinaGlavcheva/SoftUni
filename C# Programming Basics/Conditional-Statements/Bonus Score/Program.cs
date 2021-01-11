using System;

namespace Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialScores = int.Parse(Console.ReadLine());
            double bonus=0;
            int addBonus=0;

            if (initialScores <= 100) 
            {
                bonus = 5;
            } 
            else if(initialScores>100 && initialScores<=1000)
            {
                bonus = 0.2 * initialScores;
            }
            else if(initialScores>1000)
            {
                bonus = 0.1 * initialScores;
            }

            if (initialScores%2==0)
            {
                addBonus = 1;
            }
            else if(initialScores%10==5)
            {
                addBonus = 2;
            }
            double totalScores = initialScores + bonus + addBonus;
            Console.WriteLine(bonus + addBonus);
            Console.WriteLine(totalScores);
        }
    }
}
