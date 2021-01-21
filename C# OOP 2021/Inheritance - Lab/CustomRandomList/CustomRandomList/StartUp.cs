using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RandomList randomList = new RandomList();
            randomList.AddRange(new List<string>() { "1", "2", "3", "4" });
            Console.WriteLine(randomList.RandomString());
        }
    }
}
