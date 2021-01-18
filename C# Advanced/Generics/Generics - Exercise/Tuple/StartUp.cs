using System;

namespace Tuple
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine()
                .Split();

            string personInfoName = personInfo[0] + " " + personInfo[1];
            string personInfoAddress = personInfo[2];

            Tuple<string, string> personInfoTuple = new Tuple<string, string>(personInfoName, personInfoAddress);

            string[] beerInfo = Console.ReadLine()
                .Split();

            string personBeerInfoName = beerInfo[0];
            int personBeerInfoAmount = int.Parse(beerInfo[1]);

            Tuple<string, int> personBeerInfo = new Tuple<string, int>(personBeerInfoName, personBeerInfoAmount);

            string[] numbersInfo = Console.ReadLine()
                .Split();

            int numbersIntNumber = int.Parse(numbersInfo[0]);
            double numbersDoubleNumber = double.Parse(numbersInfo[1]);

            Tuple<int, double> numbersInfoTuple = new Tuple<int, double>(numbersIntNumber, numbersDoubleNumber);

            Console.WriteLine(personInfoTuple);
            Console.WriteLine(personBeerInfo);
            Console.WriteLine(numbersInfoTuple);

        }
    }
}
