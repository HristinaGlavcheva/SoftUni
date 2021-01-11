using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
           Engine engine = new Engine();

            engine.Run();

            //long capacity = long.Parse(Console.ReadLine());

            //string[] inputTreasures = Console.ReadLine()
            //    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //var bag = new Dictionary<string, Dictionary<string, long>>();
            //long gold = 0;
            //long gems = 0;
            //long cash = 0;

            //for (int i = 0; i < inputTreasures.Length; i += 2)
            //{
            //    string name = inputTreasures[i];
            //    long quantity = int.Parse(inputTreasures[i + 1]);

            //    string treasureType = string.Empty;

            //    if (name.Length == 3)
            //    {
            //        treasureType = "Cash";
            //    }
            //    else if (name.ToLower().EndsWith("gem"))
            //    {
            //        treasureType = "Gem";
            //    }
            //    else if (name.ToLower() == "gold")
            //    {
            //        treasureType = "Gold";
            //    }

            //    if (treasureType == "")
            //    {
            //        continue;
            //    }
            //    else if (capacity < bag.Values.Select(x => x.Values.Sum()).Sum() + quantity)
            //    {
            //        continue;
            //    }

            //    switch (treasureType)
            //    {
            //        case "Gem":
            //            if (!bag.ContainsKey(treasureType))
            //            {
            //                if (bag.ContainsKey("Gold"))
            //                {
            //                    if (quantity > bag["Gold"].Values.Sum())
            //                    {
            //                        continue;
            //                    }
            //                }
            //                else
            //                {
            //                    continue;
            //                }
            //            }
            //            else if (bag[treasureType].Values.Sum() + quantity > bag["Gold"].Values.Sum())
            //            {
            //                continue;
            //            }
            //            break;
            //        case "Cash":
            //            if (!bag.ContainsKey(treasureType))
            //            {
            //                if (bag.ContainsKey("Gem"))
            //                {
            //                    if (quantity > bag["Gem"].Values.Sum())
            //                    {
            //                        continue;
            //                    }
            //                }
            //                else
            //                {
            //                    continue;
            //                }
            //            }
            //            else if (bag[treasureType].Values.Sum() + quantity > bag["Gem"].Values.Sum())
            //            {
            //                continue;
            //            }
            //            break;
            //    }

            //    if (!bag.ContainsKey(treasureType))
            //    {
            //        bag[treasureType] = new Dictionary<string, long>();
            //    }

            //    if (!bag[treasureType].ContainsKey(name))
            //    {
            //        bag[treasureType][name] = 0;
            //    }

            //    bag[treasureType][name] += quantity;

            //    if (treasureType == "Gold")
            //    {
            //        gold += quantity;
            //    }
            //    else if (treasureType == "Gem")
            //    {
            //        gems += quantity;
            //    }
            //    else if (treasureType == "Cash")
            //    {
            //        cash += quantity;
            //    }
            //}

            //foreach (var x in bag)
            //{
            //    Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");

            //    foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
            //    {
            //        Console.WriteLine($"##{item2.Key} - {item2.Value}");
            //    }
            //}
        }
    }
}