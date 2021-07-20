using System;
using System.Collections.Generic;

namespace Linear_Data_Structures
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomList<int> list = new CustomList<int>();

            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            Console.WriteLine(list.Count);
            Console.WriteLine(list[list.Count-1]);

            //list.RemoveAt(0);

            //list.Remove(105);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            //Console.WriteLine(list.IndexOf(1));
            //Console.WriteLine(list.IndexOf(105));

            list.Insert(5, 555);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            Console.WriteLine();
            Console.WriteLine(list.Count);
        }
    }
}
