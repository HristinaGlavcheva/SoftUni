using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Unique_Usernames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countUsernames = int.Parse(Console.ReadLine());
            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < countUsernames; i++)
            {
                string username = Console.ReadLine();
                usernames.Add(username);
            }

            foreach (var username in usernames)
            {
                Console.WriteLine(username);
            }

            //Console.WriteLine(String.Join(Environment.NewLine, usernames));
        }
    }
}
