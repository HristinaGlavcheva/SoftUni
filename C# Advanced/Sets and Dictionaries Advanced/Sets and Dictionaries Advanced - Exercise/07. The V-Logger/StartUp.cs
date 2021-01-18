using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> vloggersFollowersInfo = new Dictionary<string, HashSet<string>>();
            Dictionary<string, HashSet<string>> vloggersFollowingsInfo = new Dictionary<string, HashSet<string>>();

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while(input[0] != "Statistics")
            {
                string command = input[1];

                if(command == "joined")
                {
                    string newVlogger = input[0];

                    if (!vloggersFollowersInfo.ContainsKey(newVlogger))
                    {
                        vloggersFollowersInfo[newVlogger] = new HashSet<string>();
                        vloggersFollowingsInfo[newVlogger] = new HashSet<string>();
                    }
                }
                else if (command == "followed")
                {
                    string followingVlogger = input[0];
                    string followedVlogger = input[2];
                    
                    if (vloggersFollowersInfo.ContainsKey(followingVlogger) && vloggersFollowersInfo.ContainsKey(followedVlogger))
                    {
                        vloggersFollowingsInfo[followedVlogger].Add(followingVlogger);
                        vloggersFollowersInfo[followingVlogger].Add(followedVlogger);
                    }
                }

                input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"The V - Logger has a total of {vloggersFollowersInfo.Count} vloggers in its logs.");

            vloggersFollowersInfo = vloggersFollowersInfo.OrderByDescending(f => f.Value.Count)
                                .ThenBy(f => f.Value)
                                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            ////followers = followers.OrderBy(f => f.Value.Count)
            //                    .ThenBy(f => f.Value)
            //                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            int counter = 1;

            foreach (var followedVlogger in vloggersFollowersInfo)
            {
                foreach (var followingVlogger in vloggersFollowingsInfo)
                {
                    if (followedVlogger.Key == followingVlogger.Key)
                    {
                        Console.WriteLine($"{counter}. {followedVlogger.Key} : {followedVlogger.Value} followers, {followingVlogger.Value} following");

                        foreach (var follower in followedVlogger.Value)
                        {
                            Console.WriteLine($"*  {follower}");
                        }

                        counter++;
                    }
                    else
                    {
                        Console.WriteLine($"{counter}. {followedVlogger.Key} : {followedVlogger.Value} followers, {followingVlogger.Value} following");
                        counter++;
                    }
                }
            }
        }
    }
}
