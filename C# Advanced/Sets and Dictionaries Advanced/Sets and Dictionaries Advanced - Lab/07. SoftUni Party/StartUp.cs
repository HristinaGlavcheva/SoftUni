using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _07._SoftUni_Party
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regGuests = new HashSet<string>();

            bool partyStarted = false;

            while(command != "END")
            {
                bool isVipGuest = char.IsDigit(command[0]);

                if (command != "PARTY" && !partyStarted)
                {
                    if (isVipGuest)
                    {
                        vipGuests.Add(command);
                    }
                    else 
                    {
                        regGuests.Add(command);
                    }
                }
                else if (command == "PARTY")
                {
                    partyStarted = true;
                }
                else if(command != "PARTY" && partyStarted)
                {
                    if (isVipGuest)
                    {
                        vipGuests.Remove(command);
                    }
                    else if (!isVipGuest)
                    {
                        regGuests.Remove(command);
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(vipGuests.Count + regGuests.Count);

            foreach (var vipGuest in vipGuests)
            {
                Console.WriteLine(vipGuest);
            }

            foreach (var regGuest in regGuests)
            {
                Console.WriteLine(regGuest);
            }
        }
    }
}
