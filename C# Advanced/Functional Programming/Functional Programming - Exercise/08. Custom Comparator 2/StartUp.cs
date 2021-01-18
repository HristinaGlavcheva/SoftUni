using System;
using System.Linq;

namespace _08._Custom_Comparator_2
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> customComparator = (x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }
                else if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }
                else
                {
                    return x.CompareTo(y);
                }
            };

            Array.Sort(numbers, new Comparison<int>(customComparator));

            //Array.Sort(numbersArray,
            //    (x, y) =>
            //    {
            //        if (x % 2 == 0 && y % 2 != 0)
            //        {
            //            return -1;
            //        }
            //        else if (x % 2 != 0 && y % 2 == 0)
            //        {
            //            return 1;
            //        }
            //        else
            //        {
            //            return x.CompareTo(y);
            //        }
            //    });

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
