using System;
using System.Linq;

namespace _12._TriFunction
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int targetNumber = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var name in names)
            {
               Func<string, int, bool> isGreater = (name, targetNumber)
                                => name.Sum(x => x) >= targetNumber;

                //int sumChars = 0;

                //foreach (var ch in name)
                //{
                //    sumChars += ch;
                //}

                //Func<int, bool> isGreater = sumChars => sumChars >= n;

                if (isGreater(name, targetNumber))
                {
                    Console.WriteLine(name);
                    break;
                }
            }

            //Func<string, int, bool> isGreater = (name, sumChars)
            //    => name.Sum(x => x) >= sumChars;

            //Func<string[], Func<string, int, bool>, string> nameFilter =
            //    (inputNames, isGreaterFilter)
            //    => inputNames.FirstOrDefault(x => isGreaterFilter(x, n));

            //string resultName = nameFilter(names, isGreater);

            //Console.WriteLine(resultName);
        }
    }
}