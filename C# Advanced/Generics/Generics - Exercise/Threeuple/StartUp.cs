using System;
using System.Text;

namespace Threeuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string[] beerInfo = Console.ReadLine().Split();
            string[] bankInfo = Console.ReadLine().Split();

            string personInfoName = personInfo[0] + " " + personInfo[1];
            string personInfoAddress = personInfo[2];

            StringBuilder sb = new StringBuilder();

            for (int i = 3; i < personInfo.Length; i++)
            {
                sb.Append(personInfo[i] + " ");
            }

            string personInfoTown = sb.ToString().TrimEnd();

            var personThreeuple = new Threeuple<string, string, string>(personInfoName, personInfoAddress, personInfoTown);

            string beerInfoName = beerInfo[0];
            int beerInfoAmount = int.Parse(beerInfo[1]);
            bool drunk = beerInfo[2] == "drunk";

            var beerThreeuple = new Threeuple<string, int, bool>(beerInfoName, beerInfoAmount, drunk);

            string bankInfoPersonName = bankInfo[0];
            double bankInfoBalance = double.Parse(bankInfo[1]);
            string bankInfoBankName = bankInfo[2];

            var bankTreeuple = new Threeuple<string, double, string>(bankInfoPersonName, bankInfoBalance, bankInfoBankName);

            Console.WriteLine(personThreeuple);
            Console.WriteLine(beerThreeuple);
            Console.WriteLine(bankTreeuple);
        }
    }
}
