using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();

            for (int i = 1; i <= 10; i++)
            {
                doublyLinkedList.AddFirst(i);
            }

            for (int i = 1; i <= 10; i++)
            {
                doublyLinkedList.AddLast(i);
            }

            doublyLinkedList.
                ForEach(n => Console.Write(n + " "));

            Console.WriteLine();
            Console.WriteLine(doublyLinkedList[5]);

            for (int i = 1; i <= 10; i++)
            {
                doublyLinkedList.RemoveFirst();
            }

            Console.WriteLine();

            doublyLinkedList.
                ForEach(n => Console.Write(n + " "));

            int[] arr = doublyLinkedList.ToArray();
        }
    }
}
